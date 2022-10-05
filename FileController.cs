using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace PassSystemManager
{
    internal class FileController
    {
        public static List<Record> Records { get; set; } = new List<Record>();

        public static string[] ReadTextFile(string filename)
        {
            var encoding = Encoding.GetEncoding(1251);
            string[] lines = File.ReadAllLines(filename, encoding);
            return lines;
        }

        public static List<Record> GetRecordsFromFile(string filename)
        {
            Records.Clear();
            var recordInfoLines = GetRecordInfosFromFile(filename);
            foreach (var line in recordInfoLines)
            {
                try
                {
                    Records.Add(new Record(line));
                }
                catch
                {

                }
            }
            return Records;
        }

        public static List<RecordInfo> GetRecordInfosFromFile(string filename)
        {
            var result = new List<RecordInfo>();
            var lines = ReadTextFile(filename);
            foreach (string line in lines)
            {
                string[] columns = line.Split(';');
                var record = new RecordInfo()
                {
                    DateTimeString = columns[0],
                    MessageSource = columns[1],
                    MessageText = columns[2]
                };
                result.Add(record);
            }
            return result;
        }

        public static List<Record> ChangeDateTime(List<Record> records, double hourOffset)
        {
            foreach (var record in records)
            {
                record.DateTime = record.DateTime.AddHours(hourOffset);
            }
            return records;
        }

        public static async Task WriteFileAsync(List<Record> records, string filename)
        {
            string[] lines = new string[records.Count];
            for (int i = 0; i < lines.Length; i++)
            {
                lines[i] = $"{records[i].DateTime}; {records[i].MessageSource}; {records[i].MessageText}";
            }

            await File.WriteAllLinesAsync(filename, lines);
            MessageBox.Show("Файл сохранен.");
        }
    }
}
