using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace WindowsFormsApplication1
{
    public class RemoveSqlComment
    {
        public RemoveSqlComment() { }

        public void Do()
        {
            StreamReader streamReader = new StreamReader(@"C:\Projects\***with_comments.sql");
            string strSource = streamReader.ReadToEnd();
            streamReader.Close();
            string[] strList = strSource.Split('\n');
            StringBuilder sb = new StringBuilder();
            foreach (string str in strList)
            {
                string strTemp = str;
                if (str.Contains("--"))
                {
                    int idx = str.IndexOf("--");
                    strTemp = str.Substring(0, idx).Trim();
                }
                sb.Append(AddStringLine(strTemp));
            }
            string strResult = sb.ToString().Trim();
            
            System.IO.File.WriteAllText(@"C:\Projects\***without_comments.sql", strResult);
        }

        private string AddStringLine(string str) {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrWhiteSpace(str))
            {
                sb.AppendLine(str.Trim());
                return sb.ToString();
            }
            else {
                return "";
            }
        }
    }
}
