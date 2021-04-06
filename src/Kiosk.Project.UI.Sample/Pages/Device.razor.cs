using Kiosk.Device.IT.NV;
using Kiosk.Device.IT.NV.Events;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kiosk.Project.UI.Sample.Pages
{
    public class DevicePage : ComponentBase, IDisposable
    {
        [Inject]
        public IConfiguration _configuration { get; set; }

        [Inject]
        protected NV_Manager _NV_Manager { get; set; }

        protected int NoteValue { get; set; }

        protected string Currency { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Yield();

            if (ValidateBillAcceptor())
            {
                _NV_Manager.NoteReadEscrowed += NV_NoteReadEscrowed;
                _NV_Manager.NoteCreditAccepted += NV_Manager_NoteCreditAccepted;

            }

        }

        private async void NV_NoteReadEscrowed(object sender, NV_NoteReadEscrowedEvent e)
        {
            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }

        private async void NV_Manager_NoteCreditAccepted(object sender, NV_NoteCreditAcceptedEvent e)
        {
            NoteValue = e.Value / 100;
            Currency = new string(e.Currency);

            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }

        private async void NV_NoteStacked(object sender, NV_NoteStackedEvent e)
        {
            await InvokeAsync(() =>
            {
                StateHasChanged();
            });
        }

        private bool ValidateBillAcceptor()
        {
            string portName = _configuration["devices:billacceptor:port"];
            var c = _NV_Manager.Connect(portName);
            if (c == false)
            {
                //ErrorMessages.Add("ValidateBillAcceptor Connect Fail");
                return false;
            }

            _NV_Manager.DebugMode = true;
            _NV_Manager.EncryptionStatus = false;

            var sync = _NV_Manager.Sync();
            var hostProtocolVersion = _NV_Manager.HostProtocolVersion();
            var initEncryption = _NV_Manager.InitEncryption();

            _NV_Manager.EncryptionStatus = true;

            var setupRequest = _NV_Manager.SetupRequest();
            _NV_Manager.SetChannelInhibits();
            _NV_Manager.ConfigureBezel();

            if (sync.ResponseStatus == NV_ResponseStatus.SSP_RESPONSE_OK &&
                hostProtocolVersion.ResponseStatus == NV_ResponseStatus.SSP_RESPONSE_OK &&
                initEncryption == true &&
                setupRequest.ResponseStatus == NV_ResponseStatus.SSP_RESPONSE_OK)
            {

                _NV_Manager.EnableValidator();

                return true;

            }
            else
            {
                //ErrorMessages.Add("ValidateBillAcceptor Setup Fail");
                return false;
            }
        }

        public async void Dispose()
        {
            await Task.Yield();

            _NV_Manager.DisableValidator();

            _NV_Manager.NoteReadEscrowed -= NV_NoteReadEscrowed;
            _NV_Manager.NoteCreditAccepted -= NV_Manager_NoteCreditAccepted;

        }
    }
}
