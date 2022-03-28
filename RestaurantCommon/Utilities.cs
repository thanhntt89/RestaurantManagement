using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Windows.Forms;
using System.Drawing;
using Microsoft.Win32;

namespace RestaurantCommon
{
    public class Utilities
    {

        public static string GetPreFixed(string existId)
        {
            // Trường hợp id là null
            if (string.IsNullOrEmpty(existId))
            {
                throw new ArgumentNullException("existedId");
            }

            int primaryKeyLenght = existId.Length;
            string tempString = string.Empty;
            bool isNumber = true;

            while (isNumber && primaryKeyLenght > 1)
            {
                try
                {
                    // Lấy chuỗi ký tự từ cuối
                    tempString = existId.Substring(primaryKeyLenght - 1, tempString.Length + 1);
                    double.Parse(tempString);
                    primaryKeyLenght--;
                }
                catch (FormatException)
                {
                    isNumber = false;
                }
            };

            return existId.Substring(0, primaryKeyLenght);
        }

        public static string CreateDiaryObjectId(string biggestId, string firstId, int lengthId)
        {
            // Tạo format string
            string format = "{0:";
            // Tính số lượng số 0
            int number = lengthId - firstId.Length;
            for (int index = 0; index < number; index++)
            {
                format += "0";
            }
            format += "}";

            // Trường hợp chưa có Id nào
            if (string.IsNullOrEmpty(biggestId))
            {
                return firstId + string.Format(format, 0);
            }
            // Trường hợp đã có Id
            else
            {
                return firstId + string.Format(format, Convert.ToInt64(biggestId.Remove(0, firstId.Length)) + 0);
            }
        }

        public static string CreatedFirstBillId(string Prefixed, DateTime dateTime)
        {
            string day, month, year, hour, min, sec;
            string billId = string.Empty;
            if (dateTime.Day > 9)
                day = dateTime.Day.ToString();
            else
                day = "0" + dateTime.Day.ToString();

            if (dateTime.Month > 9)
                month = dateTime.Month.ToString();
            else
                month = "0" + dateTime.Month.ToString();
            year = dateTime.Year.ToString();

            if (dateTime.Hour > 9)
                hour = dateTime.Hour.ToString();
            else
                hour = "0" + dateTime.Hour.ToString();

            if (dateTime.Minute > 9)
                min = dateTime.Minute.ToString();
            else
                min = "0" + dateTime.Minute.ToString();

            if (dateTime.Second > 9)
                sec = dateTime.Second.ToString();
            else
                sec = "0" + dateTime.Second.ToString();
            billId = Prefixed + day + month + year + hour + min + sec;

            return billId;
        }

        public static string NextID(string lastID, string prefixID)
        {
            if (string.IsNullOrEmpty(lastID))
            {
                return prefixID + "0000000000001";  // fixwidth default
            }
            int nextID = int.Parse(lastID.Remove(0, prefixID.Length)) + 1;
            int lengthNumerID = lastID.Length - prefixID.Length;
            string zeroNumber = string.Empty;
            for (int i = 1; i <= lengthNumerID; i++)
            {
                if (nextID < Math.Pow(10, i))
                {
                    for (int j = 1; j <= lengthNumerID - i; i++)
                    {
                        zeroNumber += "0";
                    }
                    return prefixID + zeroNumber + nextID.ToString();
                }
            }
            return prefixID + nextID;

        }

        /// <summary>
        /// Mã hóa password
        /// </summary>
        /// <param name="target">Chuỗi mã hóa</param>
        /// <returns>Mật khẩu đã mã hóa</returns>
        public static string ComputeHash(string target)
        {
            SHA256Managed hashAlgorithm = new SHA256Managed();

            byte[] data = System.Text.Encoding.ASCII.GetBytes(target);

            byte[] bytes = hashAlgorithm.ComputeHash(data);

            return BitConverter.ToString(bytes).ToLower().Replace("-", string.Empty);
        }

        /// <summary>
        /// Encrypt password using
        /// </summary>
        /// <param name="inputString">input string</param>
        /// <returns>The encrypted string</returns>
        public static string CreateSalt()
        {
            // Create salt
            string salt = string.Empty;

            Random random = new Random();

            while (salt.Length < 32)
            {
                salt = salt + Convert.ToString(random.Next(0, 9));
            }

            return salt;
        }

        public static ImageList getImageList(byte[] obj)
        {
            ImageList imgList = new ImageList();

            if (obj == null)
                return null;
            else
            {
                Image myImage = ConvertByteToImage(obj);
                imgList.ImageSize = new Size(30, 30);
                imgList.Images.Add(myImage);
                return imgList;
            }
        }

        public static Image ConvertByteToImage(byte[] obj)
        {
            if (obj == null)
                return null;
            else
            {
                MemoryStream ms = new MemoryStream(obj);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }

        public static byte[] ConvertImageToByte(System.Drawing.Image imageIn)
        {
            if (imageIn == null)
                return null;
            MemoryStream ms = new MemoryStream();
            imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            return ms.ToArray();
        }

        /// <summary>
        /// Chuyển từ hình ảnh sang byte để lưu vào database
        /// </summary>
        /// <param name="imagePath">Đường dẫn của ảnh</param>
        /// <returns>Giá trị byte của ảnh</returns>
        public static byte[] ConvertImgeToByte(OpenFileDialog OpenFileName, PictureBox PicName)
        {
            byte[] img = null;
            try
            {
                //Cho phép thêm vào tên mở rộng
                OpenFileName.AddExtension = true;

                //Kiểm tra một tập tin người dùng chọn có đúng hay ko? nếu ko thì hiện thông báo cảnh báo
                OpenFileName.CheckFileExists = true;

                //Kiểm tra đường dẫn có đúng ko? nếu ko cũng hiện cảnh báo.
                OpenFileName.CheckPathExists = true;

                //Lọc các định dạng mở rộng.
                OpenFileName.Filter = "Image files (*.jpg;*.gif;*.bmp;*.jpeg)|*.jpeg;*.jpg;*.gif;*.bmp;*.png";
                // "txt files (*.txt)|*.txt|All files (*.*)|*.*";

                //Chỉ cho phép chọn một anh khi chọn
                OpenFileName.Multiselect = false;

                //Tiêu đề của hộp thoại
                OpenFileName.Title = "Bạn hãy chọn ảnh thích hợp!";
                OpenFileName.FileName = string.Empty;
                OpenFileName.AutoUpgradeEnabled = false;
                if (OpenFileName.ShowDialog() == DialogResult.OK)
                {
                    //Lấy đừng dẫn của file đã chọn
                    string Path = OpenFileName.FileName;

                    FileStream Stream = new FileStream(Path, FileMode.Open, FileAccess.Read);
                    MemoryStream memoryStream = new MemoryStream();
                    Image.FromStream(Stream).Save(memoryStream, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //Gán ảnh vào Picturebox
                    img = memoryStream.ToArray();
                    PicName.Image = Image.FromStream(Stream);
                }
            }
            catch
            {
                MessageBox.Show("Bạn phải chọn tệp ảnh");
            }
            return img;
        }

        /// <summary>
        /// Lưu thông tin kết cũ của kết nối vào Registry
        /// </summary>
        /// <param name="sqlConnectString"></param>
        public static void SaveInforConnectionApplicationTemp(string sqlConnectString)
        {
            try
            {
                RegistryKey subkey = Registry.LocalMachine.CreateSubKey("Software\\ThanhNT\\RestaurantManagement");
                string md5Connect = Utilities.EnCryptMD5(sqlConnectString, Utilities.CKEY, true);
                subkey.SetValue("ConnectApplicationManagementSystemTemp", md5Connect);
                subkey.Close();
            }
            catch
            {
            }
        }

        public static string CKEY = Constants.RestaurantManagement;

        /// <summary>
        /// Hàm mã hóa theo thuật toán MD5
        /// </summary>
        /// <param name="toEncrypt"></param>
        /// <param name="key"></param>
        /// <param name="useHashing"></param>
        /// <returns></returns>
        public static string EnCryptMD5(string toEncrypt, string key, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        /// <summary>
        /// Hàm giải mã hóa
        /// </summary>
        /// <param name="toDecrypt"></param>
        /// <param name="key"></param>
        /// <param name="useHashing"></param>
        /// <returns></returns>
        public static string DeCryptMD5(string toDecrypt, string key, bool useHashing)
        {
            byte[] keyArray;
            byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

            if (useHashing)
            {
                MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            TripleDESCryptoServiceProvider tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return UTF8Encoding.UTF8.GetString(resultArray);
        }

        public static int GetLastDayOfMonth(DateTime dateTime)
        {
            DateTime endOfMonth = new DateTime(dateTime.Year, dateTime.Month, DateTime.DaysInMonth(dateTime.Year, dateTime.Month));

            return endOfMonth.Day;
        }

        /// <summary>
        /// kiểm tra chuỗi rỗng hoặc null và có độ dài trong khoảng
        /// </summary>
        /// <param name="text">Text</param>
        /// <param name="minLength">Độ dài nhỏ nhất</param>
        /// <param name="maxLength">Độ dài lớn nhất</param>
        /// <param name="parameter">Chuỗi cần hiển thị. Viết hoa đầu câu</param>
        /// <returns></returns>
        public static bool CheckNullOrMinMaxLength(string lableText, string textBox, int minLength, int maxLength)
        {
            // Trường hợp chuỗi rỗng hoặc null
            if (string.IsNullOrEmpty(textBox))
            {
                MessageBox.Show(lableText + " không được để trống", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            // Độ dài không nằm trong khoảng cho phép
            else if (textBox.Length < minLength || textBox.Length > maxLength)
            {
                MessageBox.Show(lableText + " phải có độ dài lớn hơn " + minLength + " và nhỏ hơn " + maxLength + " ký tự", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public static bool CheckMaxLength(string lableText, string textBox, int maxLength)
        {
            // Độ dài không nằm trong khoảng cho phép
            if (textBox.Length > maxLength)
            {
                MessageBox.Show(lableText + " phải có độ dài nhỏ hơn " + maxLength + " ký tự", Constants.CaptionErrorMessage, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        public static string DocSo(decimal number)
        {
            string str = string.Empty;
            string s = number.ToString("#");
            string[] so = new string[] { "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string[] hang = new string[] { "", "nghìn", "triệu", "tỷ" };
            int i, j, donvi, chuc, tram;

            bool booAm = false;
            decimal decS = 0;
            //Tung addnew
            try
            {
                decS = Convert.ToDecimal(s.ToString());
            }
            catch
            {
            }
            if (decS < 0)
            {
                decS = -decS;
                s = decS.ToString();
                booAm = true;
            }
            i = s.Length;
            if (i == 0)
                str = so[0] + str;
            else
            {
                j = 0;
                while (i > 0)
                {
                    donvi = Convert.ToInt32(s.Substring(i - 1, 1));
                    i--;
                    if (i > 0)
                        chuc = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        chuc = -1;
                    i--;
                    if (i > 0)
                        tram = Convert.ToInt32(s.Substring(i - 1, 1));
                    else
                        tram = -1;
                    i--;
                    if ((donvi > 0) || (chuc > 0) || (tram > 0) || (j == 3))
                        str = hang[j] + str;
                    j++;
                    if (j > 3) j = 1;
                    if ((donvi == 1) && (chuc > 1))
                        str = "mốt " + str;
                    else
                    {
                        if ((donvi == 5) && (chuc > 0))
                            str = "lăm " + str;
                        else if (donvi > 0)
                            str = so[donvi] + " " + str;
                    }
                    if (chuc < 0)
                        break;
                    else
                    {
                        if ((chuc == 0) && (donvi > 0)) str = "linh " + str;
                        if (chuc == 1) str = "mười " + str;
                        if (chuc > 1) str = so[chuc] + " mươi " + str;
                    }
                    if (tram < 0) break;
                    else
                    {
                        if ((tram > 0) || (chuc > 0) || (donvi > 0)) str = so[tram] + " trăm " + str;
                    }
                    str = " " + str;
                }
            }
            if (booAm) str = "Âm " + str;
            return str = str + "đồng";
        }

        private static string ConvertToTitleCase(string s)
        {
            return System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToLower(s);
        }

        public static void AutoIndex(DataGridView dataGridView, int ColumIndex)
        {
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                dataGridView.Rows[i].Cells[ColumIndex].Value = i + 1;
            }
        }
    }
}
