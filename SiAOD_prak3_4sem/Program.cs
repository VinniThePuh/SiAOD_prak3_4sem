using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiAOD_prak3_4sem
{
    static class Program
    {
        public struct data
        {
            public string date;
            public string temp;
            public string tempmi;
            public string tempma;
        }

        [STAThread]
        static void Main()
        {
            data[] arr = new data[4000];
            WebClient wc = new WebClient();
            string answer = wc.DownloadString("https://api.meteostat.net/v1/history/daily?station=26666&start=2010-01-01&end=2019-12-31&key=HYvZ90Hg");
            int length = answer.Length;
            int n = answer.Length;

            int j = 0;
            int k = 0;

            bool flag = false;

            string str = "";
            for (int i = 0; i < n - 4; i++)
            {
                if (flag == false)
                {
                    if (answer[i] == 'd' && answer[i + 1] == 'a' && answer[i + 2] == 't' && answer[i + 3] == 'e')
                    {
                        flag = true;
                        i += 6;
                    }
                    if (answer[i] == 't' && answer[i + 1] == 'e' && answer[i + 2] == 'm' && answer[i + 3] == 'p' && answer[i + 4] == 'e' && answer[i + 5] == 'r' && answer[i + 6] == 'a' && answer[i + 7] == 't' && answer[i + 8] == 'u' && answer[i + 9] == 'r' && answer[i + 10] == 'e' && answer[i + 11] == '_')
                    {
                        flag = true;
                        i += 16;
                        if (answer[i] == '\"')
                        {
                            i++;
                        }
                    }
                    else
                    {
                        if (answer[i] == 't' && answer[i + 1] == 'e' && answer[i + 2] == 'm' && answer[i + 3] == 'p' && answer[i + 4] == 'e' && answer[i + 5] == 'r' && answer[i + 6] == 'a' && answer[i + 7] == 't' && answer[i + 8] == 'u' && answer[i + 9] == 'r' && answer[i + 10] == 'e')
                        {
                            flag = true;
                            i += 12;
                            if (answer[i] == '\"')
                            {
                                i++;
                            }
                        }
                    }
                }
                else  {
                    if ((answer[i] >= '0' && answer[i] <= '9') || (answer[i] >= '9' && answer[i] <= '0') || answer[i] == '-' || answer[i] == 'n' || answer[i] == 'u' || answer[i] == 'l' || answer[i] == '.')
                    {
                        if (answer[i] == '.')
                        {
                            str += ',';
                        }
                        else
                        {
                            str += answer[i];
                        }
                    } else
                    {
                        flag = false;
                        switch (k % 4)
                        {
                            case 0:
                                {
                                    arr[j].date = str;
                                    Class1.transs[j] = str;
                                    break;
                                }
                            case 1:
                                {
                                    arr[j].temp = str;
                                    break;
                                }
                            case 2:
                                {
                                    arr[j].tempmi = str;
                                    break;
                                }
                            case 3:
                                {
                                    arr[j].tempma = str;
                                    j++;
                                    break;
                                }
                        }
                        k++;
                        str = "";
                    }
                }
            }

            Class1.num = j;
            n = j;

            for (int i = 0; i < n; i++)
            {
                
                if (arr[i].temp == "null")
                {
                    if (arr[i].tempmi != "null" && arr[i].tempma != "null")
                    {
                        double a1 = Convert.ToDouble(arr[i].tempmi);
                        double a2 = Convert.ToDouble(arr[i].tempma);
                        double a3 = (a1 + a2) / 2;
                        arr[i].temp = Convert.ToString(a3);
                    }
                    else
                    {
                        if (arr[i].tempmi == "null" && arr[i].tempma == "null")
                        {
                            arr[i].temp = arr[i - 1].temp;
                        }
                        else
                        {
                            if (arr[i].tempmi != "null")
                            {
                                arr[i].temp = arr[i].tempmi;
                            }
                            else
                            {
                                arr[i].temp = arr[i].tempma;
                            }
                        }
                    }
                }

                Class1.transi[i] = Convert.ToDouble(arr[i].temp);
            }
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
