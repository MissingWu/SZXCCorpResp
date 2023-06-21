using System;
using System.Threading;
using System.IO;
using System.Windows.Forms;

namespace Common
{
    public class UTool
    {
        static public double timeout;

        public static bool CheckRegist(string key)
        {
            bool timer = false;
            var helper = new EncryptionHelper(EncryptionKeyEnum.KeyB);
            if (key != "")
            {
                string computerKey = key.Substring(0,80);
                string timeKey = key.Substring(80);
                //MessageBox.Show(computerKey);
                //MessageBox.Show(timeKey);
                string md5key1 = helper.DecryptString(computerKey);
                
                string computer = ComputerInfo.GetComputerInfo();
                EncryptionHelper help = new EncryptionHelper(EncryptionKeyEnum.KeyB);
                string md5key2 = help.GetMD5String(computer);
                string key5 = helper.DecryptString(timeKey);//上次时间+期限天数（第一次为注册机生成注册码时间）
                DateTime time = Convert.ToDateTime(key5.Split('&')[0]);//上次时间（第一次为注册机生成注册码时间）
                timeout = Convert.ToDouble(key5.Split('&')[1])*24;//上次启动后剩余期限（小时）
                DateTime dt = System.DateTime.Now;//客户端现在的时间，有可能被修改过,理论是比上次时间（或注册机生成时间）大
                
                TimeSpan u= (dt - time);
                double spanHours = u.TotalHours;
                timeout = (timeout - spanHours);//本次剩余期限（小时）
                if ((spanHours+0.1) < 0)//+0.1,可能时间有点误差，设置一个容差半小时
                {
                        MessageBox.Show("客户端时间可能被修改！");
                        timer = false;  
                }
                else
                {
                    if (timeout > 0)
                    {
                        timer = true;
                    }
                    else
                    {
                        MessageBox.Show("程序已过期，请重新注册！");
                        timer = false;
                    }

                }
                if (md5key1 == md5key2 && timer ==true)
                {
                    timeout = timeout / 24;//剩余期限（天）
                    string timekey = help.EncryptString(dt + "&" + timeout);
                    RegistFileHelper.WriteRegistFile(computerKey + timekey);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
    }
}
