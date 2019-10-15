using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BsalsePro.ClassForm
{
    public class Encryption
    {
        // Token: 0x0600083A RID: 2106 RVA: 0x000729E8 File Offset: 0x00070BE8
        public static string InverseByBase(string st, int MoveBase)
        {
            StringBuilder stringBuilder = new StringBuilder();
            checked
            {
                for (int i = 0; i < st.Length; i += MoveBase)
                {
                    bool flag = i + MoveBase > st.Length - 1;
                    int length;
                    if (flag)
                    {
                        length = st.Length - i;
                    }
                    else
                    {
                        length = MoveBase;
                    }
                    stringBuilder.Append(Encryption.InverseString(st.Substring(i, length)));
                }
                return stringBuilder.ToString();
            }
        }

        // Token: 0x0600083B RID: 2107 RVA: 0x00072A58 File Offset: 0x00070C58
        public static string InverseString(string st)
        {
            StringBuilder stringBuilder = new StringBuilder();
            checked
            {
                int num = st.Length - 1;
                for (int i = num; i >= 0; i += -1)
                {
                    stringBuilder.Append(st[i]);
                }
                return stringBuilder.ToString();
            }
        }

        // Token: 0x0600083C RID: 2108 RVA: 0x00072A9C File Offset: 0x00070C9C
        public static string ConvertToLetterDigit(string st)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char c in st)
            {
                bool flag = !char.IsLetterOrDigit(c);
                if (flag)
                {
                    stringBuilder.Append(Convert.ToInt16(c).ToString());
                }
                else
                {
                    stringBuilder.Append(c);
                }
            }
            return stringBuilder.ToString();
        }

        // Token: 0x0600083D RID: 2109 RVA: 0x00072B14 File Offset: 0x00070D14
        public static string Boring(string st)
        {
            checked
            {
                int num = st.Length - 1;
                for (int i = 0; i <= num; i++)
                {
                    int num2 = i * (int)Convert.ToUInt16(st[i]);
                    num2 %= st.Length;
                    char c = st[i];
                    st = st.Remove(i, 1);
                    st = st.Insert(num2, c.ToString());
                }
                return st;
            }
        }

        // Token: 0x0600083E RID: 2110 RVA: 0x00072B80 File Offset: 0x00070D80
        public static string MakePassword(string st, string Identifier)
        {
            bool flag = Identifier.Length != 3;
            if (flag)
            {
                throw new ArgumentException("Identifier must be 3 character length");
            }
            int[] array = new int[]
            {
            Convert.ToInt32(Identifier[0].ToString(), 10),
            Convert.ToInt32(Identifier[1].ToString(), 10),
            Convert.ToInt32(Identifier[2].ToString(), 10)
            };
            st = Encryption.Boring(st);
            st = Encryption.InverseByBase(st, array[0]);
            st = Encryption.InverseByBase(st, array[1]);
            st = Encryption.InverseByBase(st, array[2]);
            StringBuilder stringBuilder = new StringBuilder();
            foreach (char ch in st)
            {
                stringBuilder.Append(Encryption.ChangeChar(ch, array));
            }
            return stringBuilder.ToString();
        }

        // Token: 0x0600083F RID: 2111 RVA: 0x00072C74 File Offset: 0x00070E74
        private static char ChangeChar(char ch, int[] EnCode)
        {
            ch = char.ToUpper(ch);
            bool flag = ch >= 'A' && ch <= 'H';
            checked
            {
                char result;
                if (flag)
                {
                    result = Convert.ToChar((int)Convert.ToInt16(ch) + 2 * EnCode[0]);
                }
                else
                {
                    bool flag2 = ch >= 'I' && ch <= 'P';
                    if (flag2)
                    {
                        result = Convert.ToChar((int)Convert.ToInt16(ch) - EnCode[2]);
                    }
                    else
                    {
                        bool flag3 = ch >= 'Q' && ch <= 'Z';
                        if (flag3)
                        {
                            result = Convert.ToChar((int)Convert.ToInt16(ch) - EnCode[1]);
                        }
                        else
                        {
                            bool flag4 = ch >= '0' && ch <= '4';
                            if (flag4)
                            {
                                result = Convert.ToChar((int)(Convert.ToInt16(ch) + 5));
                            }
                            else
                            {
                                bool flag5 = ch >= '5' && ch <= '9';
                                if (flag5)
                                {
                                    result = Convert.ToChar((int)(Convert.ToInt16(ch) - 5));
                                }
                                else
                                {
                                    result = '0';
                                }
                            }
                        }
                    }
                }
                return result;
            }
        }
    }

}
