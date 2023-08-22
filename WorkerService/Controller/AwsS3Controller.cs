using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WorkerService.Model;

namespace WorkerService.Controller
{
    class AwsS3Controller
    {
        private UploadAWSService uploadAWS = new UploadAWSService();

        public async Task UploadFile(string connectionString, AwsS3Info awsS3Info)
        {
            Log _logger = new Logger();
            var data = uploadAWS.ScanUpload(connectionString);
            string idError = "";
            try
            {
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    var filePath = "";
                    if (!String.IsNullOrEmpty(awsS3Info.FTPFolderRoot))
                    {
                        idError = "";
                        filePath = awsS3Info.FTPFolderRoot + data.Rows[i]["URL"].ToString();
                        _logger.Info(String.Format("{0} Kiểm tra đường dẫn {1}", i + 1, filePath));
                        FtpWebRequest fileRequest = (FtpWebRequest)WebRequest.Create(filePath);
                        fileRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                        fileRequest.Credentials = new NetworkCredential(awsS3Info.FTPUserName, awsS3Info.FTPPassword);
                        using (Stream fileResponse = fileRequest.GetResponse().GetResponseStream())
                        {
                            var id = data.Rows[i]["ID"].ToString();
                            idError = id;
                            var fileName = data.Rows[i]["Name"].ToString();
                            bool result = await uploadAWS.UploadFileAsync(fileResponse, fileName, filePath, connectionString, id, awsS3Info);
                            if (result)
                                _logger.Info(String.Format("{0} Upload thành công {1} - ID: {2}", i + 1, filePath, id));
                            else
                            {
                                _logger.Info(String.Format("{0} Không thành công {1} - ID: {2}", i + 1, filePath, id));
                                uploadAWS.UpdateFail(connectionString, id);
                            }
                        }
                    }
                    else
                    {
                        idError = "";
                        filePath = awsS3Info.FolderRoot + data.Rows[i]["URL"].ToString();
                        var id = data.Rows[i]["ID"].ToString();
                        idError = id;
                        FileInfo fileInfo = new FileInfo(filePath);
                        if (!File.Exists(filePath))
                        {
                            _logger.Info(String.Format("{0} Không thấy đường dẫn {1} - ID: {2}", i + 1, filePath, id));
                            uploadAWS.UpdateStatusNotFound(connectionString, id);
                        }
                        else
                        {
                            _logger.Info(String.Format("{0} Đang upload đường dẫn {1} - ID: {2}", i + 1, filePath, id));

                            using (FileStream fileStream = fileInfo.OpenRead())
                            {
                                bool result = await uploadAWS.UploadFileAsync(fileStream, fileInfo.Name, filePath, connectionString, id, awsS3Info);
                                if (result)
                                    _logger.Info(String.Format("{0} Upload thành công {1} - ID: {2}", i + 1, filePath, id));
                                else
                                {
                                    _logger.Info(String.Format("{0} Không thành công {1} - ID: {2}", i + 1, filePath, id));
                                    uploadAWS.UpdateFail(connectionString, id);
                                }

                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.Error(String.Format("Lỗi {0}", ex.Message));
                if (!String.IsNullOrEmpty(idError))
                    uploadAWS.UpdateFail(connectionString, idError);
                throw;
            }

        }

        public static MemoryStream CopyToMemory(Stream input)
        {
            MemoryStream ret = new MemoryStream();

            byte[] buffer = new byte[8192];
            int bytesRead;
            while ((bytesRead = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                ret.Write(buffer, 0, bytesRead);
            }
            ret.Position = 0;
            return ret;
        }
    }

}
