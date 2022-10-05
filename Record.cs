using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassSystemManager
{
    class Record
    {
        public DateTime DateTime { get; set; }

        public string MessageSource { get; set; } = "";

        public string MessageText { get; set; } = "";

        public Record(RecordInfo recordInfo)
        {
            DateTime = DateTime.ParseExact(recordInfo.DateTimeString, "dd.MM.yy HH:mm:ss", null);
            MessageSource = recordInfo.MessageSource;
            MessageText = recordInfo.MessageText;
        }
    }

    class RecordInfo
    {
        public string DateTimeString { get; set; } = "";

        public string MessageSource { get; set; } = "";

        public string MessageText { get; set; } = "";
    }
}
