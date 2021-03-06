using System;
using System.Collections.Generic;
using System.Text;

namespace Kiosk.Device.IT.NV
{
    public partial class NV_Manager
    {
        const byte SEQUENCE = 0x80;
        const byte STX = 0x7F;
        const byte STEX = 0x7E;
        const byte CMD_RESET = 0x01;
        const byte CMD_SET_CHANNEL_INHIBITS = 0x02;
        const byte CMD_DISPLAY_ON = 0x03;
        const byte CMD_DISPLAY_OFF = 0x04;
        const byte CMD_SETUP_REQUEST = 0x05;
        const byte CMD_HOST_PROTOCOL_VERSION = 0x06;
        const byte CMD_POLL = 0x07;
        const byte CMD_REJECT_BANKNOTE = 0x08;
        const byte CMD_DISABLE = 0x09;
        const byte CMD_ENABLE = 0x0A;
        const byte CMD_GET_SERIAL_NUMBER = 0x0C;
        const byte CMD_UNIT_DATA = 0x0D;
        const byte CMD_CHANNEL_VALUE_REQUEST = 0x0E;
        const byte CMD_CHANNEL_SECURITY_DATA = 0x0F;
        const byte CMD_CHANNEL_RE_TEACH_DATA = 0x10;
        const byte CMD_SYNC = 0x11;
        const byte CMD_LAST_REJECT_CODE = 0x17;
        const byte CMD_HOLD = 0x18;
        const byte CMD_GET_FIRMWARE_VERSION = 0x20;
        const byte CMD_GET_DATASET_VERSION = 0x21;
        const byte CMD_GET_ALL_LEVELS = 0x22;
        const byte CMD_GET_BAR_CODE_READER_CONFIGURATION = 0x23;
        const byte CMD_SET_BAR_CODE_CONFIGURATION = 0x24;
        const byte CMD_GET_BAR_CODE_INHIBIT_STATUS = 0x25;
        const byte CMD_SET_BAR_CODE_INHIBIT_STATUS = 0x26;
        const byte CMD_GET_BAR_CODE_DATA = 0x27;
        const byte CMD_SET_REFILL_MODE = 0x30;
        const byte CMD_PAYOUT_AMOUNT = 0x33;
        const byte CMD_SET_DENOMINATION_LEVEL = 0x34;
        const byte CMD_GET_DENOMINATION_LEVEL = 0x35;
        const byte CMD_COMMUNICATION_PASS_THROUGH = 0x37;
        const byte CMD_HALT_PAYOUT = 0x38;
        const byte CMD_SET_DENOMINATION_ROUTE = 0x3B;
        const byte CMD_GET_DENOMINATION_ROUTE = 0x3C;
        const byte CMD_FLOAT_AMOUNT = 0x3D;
        const byte CMD_GET_MINIMUM_PAYOUT = 0x3E;
        const byte CMD_EMPTY_ALL = 0x3F;
        const byte CMD_SET_COIN_MECH_INHIBITS = 0x40;
        const byte CMD_GET_NOTE_POSITIONS = 0x41;
        const byte CMD_PAYOUT_NOTE = 0x42;
        const byte CMD_STACK_NOTE = 0x43;
        const byte CMD_FLOAT_BY_DENOMINATION = 0x44;
        const byte CMD_SET_VALUE_REPORTING_TYPE = 0x45;
        const byte CMD_PAYOUT_BY_DENOMINATION = 0x46;
        const byte CMD_SET_COIN_MECH_GLOBAL_INHIBIT = 0x49;
        const byte CMD_SET_GENERATOR = 0x4A;
        const byte CMD_SET_MODULUS = 0x4B;
        const byte CMD_REQUEST_KEY_EXCHANGE = 0x4C;
        const byte CMD_SET_BAUD_RATE = 0x4D;
        const byte CMD_GET_BUILD_REVISION = 0x4F;
        const byte CMD_SET_HOPPER_OPTIONS = 0x50;
        const byte CMD_GET_HOPPER_OPTIONS = 0x51;
        const byte CMD_SMART_EMPTY = 0x52;
        const byte CMD_CASHBOX_PAYOUT_OPERATION_DATA = 0x53;
        const byte CMD_CONFIGURE_BEZEL = 0x54;
        const byte CMD_POLL_WITH_ACK = 0x56;
        const byte CMD_EVENT_ACK = 0x57;
        const byte CMD_GET_COUNTERS = 0x58;
        const byte CMD_RESET_COUNTERS = 0x59;
        const byte CMD_COIN_MECH_OPTIONS = 0x5A;
        const byte CMD_DISABLE_PAYOUT_DEVICE = 0x5B;
        const byte CMD_ENABLE_PAYOUT_DEVICE = 0x5C;
        const byte CMD_SET_FIXED_ENCRYPTION_KEY = 0x60;
        const byte CMD_RESET_FIXED_ENCRYPTION_KEY = 0x61;
        const byte CMD_REQUEST_TEBS_BARCODE = 0x65;
        const byte CMD_REQUEST_TEBS_LOG = 0x66;
        const byte CMD_TEBS_UNLOCK_ENABLE = 0x67;
        const byte CMD_TEBS_UNLOCK_DISABLE = 0x68;

        const byte POLL_TEBS_CASHBOX_OUT_OF_SERVICE = 0x90;
        const byte POLL_TEBS_CASHBOX_TAMPER = 0x91;
        const byte POLL_TEBS_CASHBOX_IN_SERVICE = 0x92;
        const byte POLL_TEBS_CASHBOX_UNLOCK_ENABLED = 0x93;
        const byte POLL_JAM_RECOVERY = 0xB0;
        const byte POLL_ERROR_DURING_PAYOUT = 0xB1;
        const byte POLL_SMART_EMPTYING = 0xB3;
        const byte POLL_SMART_EMPTIED = 0xB4;
        const byte POLL_CHANNEL_DISABLE = 0xB5;
        const byte POLL_INITIALISING = 0xB6;
        const byte POLL_COIN_MECH_ERROR = 0xB7;
        const byte POLL_EMPTYING = 0xC2;
        const byte POLL_EMPTIED = 0xC3;
        const byte POLL_COIN_MECH_JAMMED = 0xC4;
        const byte POLL_COIN_MECH_RETURN_PRESSED = 0xC5;
        const byte POLL_PAYOUT_OUT_OF_SERVICE = 0xC6;
        const byte POLL_NOTE_FLOAT_REMOVED = 0xC7;
        const byte POLL_NOTE_FLOAT_ATTACHED = 0xC8;
        const byte POLL_NOTE_TRANSFERED_TO_STACKER = 0xC9;
        const byte POLL_NOTE_PAID_INTO_STACKER_AT_POWER_UP = 0xCA;
        const byte POLL_NOTE_PAID_INTO_STORE_AT_POWER_UP = 0xCB;
        const byte POLL_NOTE_STACKING = 0xCC;
        const byte POLL_NOTE_DISPENSED_AT_POWER_UP = 0xCD;
        const byte POLL_NOTE_HELD_IN_BEZEL = 0xCE;
        const byte POLL_BAR_CODE_TICKET_ACKNOWLEDGE = 0xD1;
        const byte POLL_DISPENSED = 0xD2;
        const byte POLL_JAMMED = 0xD5;
        const byte POLL_HALTED = 0xD6;
        const byte POLL_FLOATING = 0xD7;
        const byte POLL_FLOATED = 0xD8;
        const byte POLL_TIME_OUT = 0xD9;
        const byte POLL_DISPENSING = 0xDA;
        const byte POLL_NOTE_STORED_IN_PAYOUT = 0xDB;
        const byte POLL_INCOMPLETE_PAYOUT = 0xDC;
        const byte POLL_INCOMPLETE_FLOAT = 0xDD;
        const byte POLL_CASHBOX_PAID = 0xDE;
        const byte POLL_COIN_CREDIT = 0xDF;
        const byte POLL_NOTE_PATH_OPEN = 0xE0;
        const byte POLL_NOTE_CLEARED_FROM_FRONT = 0xE1;
        const byte POLL_NOTE_CLEARED_TO_CASHBOX = 0xE2;
        const byte POLL_CASHBOX_REMOVED = 0xE3;
        const byte POLL_CASHBOX_REPLACED = 0xE4;
        const byte POLL_BAR_CODE_TICKET_VALIDATED = 0xE5;
        const byte POLL_FRAUD_ATTEMPT = 0xE6;
        const byte POLL_STACKER_FULL = 0xE7;
        const byte POLL_DISABLED = 0xE8;
        const byte POLL_UNSAFE_NOTE_JAM = 0xE9;
        const byte POLL_SAFE_NOTE_JAM = 0xEA;
        const byte POLL_NOTE_STACKED = 0xEB;
        const byte POLL_NOTE_REJECTED = 0xEC;
        const byte POLL_NOTE_REJECTING = 0xED;
        const byte POLL_CREDIT_NOTE = 0xEE;
        const byte POLL_READ_NOTE = 0xEF;
        const byte POLL_SLAVE_RESET = 0xF1;

        const byte RESPONSE_OK = 0xF0;
        const byte RESPONSE_COMMAND_NOT_KNOWN = 0xF2;
        const byte RESPONSE_WRONG_NO_PARAMETERS = 0xF3;
        const byte RESPONSE_PARAMETER_OUT_OF_RANGE = 0xF4;
        const byte RESPONSE_COMMAND_CANNOT_BE_PROCESSED = 0xF5;
        const byte RESPONSE_SOFTWARE_ERROR = 0xF6;
        const byte RESPONSE_FAIL = 0xF8;
        const byte RESPONSE_KEY_NOT_SET = 0xFA;
    }
}
