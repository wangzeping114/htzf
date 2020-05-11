<%@ WebHandler Language="C#" Class="CreateTempImageTest" %>

using System;
using System.Web;
using System.IO;
using System.Drawing;
using System.Text;
using System.Collections;
using System.Drawing.Imaging;
using System.Configuration;
using System.Net;

public class CreateTempImageTest : IHttpHandler
{
    private string ftpPassword = ConfigurationManager.AppSettings["ftpPassword"].ToString();
    private string ftpServerIP = ConfigurationManager.AppSettings["ftpServerIP"].ToString();
    private string ftpUserID = ConfigurationManager.AppSettings["ftpUserID"].ToString();
    private FtpWebRequest reqFTP;
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        Hashtable res = new Hashtable();
        try
        {
            //获取当前Post过来的file集合对象,在这里我只获取了<input type='file' name='fileUp'/>的文件控件
            string groupid = context.Request["groupid"];
            string action = context.Request["action"];
            System.Collections.Specialized.NameValueCollection form = context.Request.Form;

            if (string.IsNullOrWhiteSpace(groupid) || string.IsNullOrWhiteSpace(action))
            {
                context.Response.Write("false|缺少必要参数");
            }
            else
            {
                switch (action)
                { 
                    case "temp":
                        CreateTemp(context, groupid);
                        break;
                    case "upload":
                        UploadImg(context, groupid);
                        break;
                    case "BaseToImage":
                        Base64Img(context, groupid);
                        break;
                    default:
                        context.Response.Write("false|未知操作");
                        break;
                }
            }
            
        }
        catch (Exception e)
        {
            //上传失败 
            context.Response.Write("false|上传失败"+e.Message);
        }
    }

    private void CreateTemp(HttpContext context, string groupid)
    {
        HttpPostedFile file = context.Request.Files["fileUp"];
        if (file != null)
        {
            //当前文件上传的目录
            string path = context.Server.MapPath("~/Controls/images/");
            
            // 判断集团目录是否存在
            if (!Directory.Exists(path + groupid))
            {
                // 不存在就创建
                Directory.CreateDirectory(path + groupid);
            }
            else
            { 
                // 存在就将目录里的临时图片全部删除
                foreach (string tempImg in Directory.GetFiles(path + groupid))
                {
                    if (File.Exists(tempImg))
                    {
                        File.Delete(tempImg);
                    }
                }
            }
            // 将groupid拼接入path
            path += groupid + "/";
            
            //当前待上传的服务端路径
            string imageName = Guid.NewGuid().ToString().Replace("-", "");
            string imageUrl = path + imageName;//Path.GetFileName(file.FileName);
            //当前文件后缀名
            string ext = Path.GetExtension(file.FileName).ToLower();
            imageUrl += ext;
            //验证文件类型是否正确
            if (!ext.Equals(".gif") && !ext.Equals(".jpg") && !ext.Equals(".jpeg") && !ext.Equals(".png") && !ext.Equals(".bmp"))
            {
                //这里window.parent.uploadSuccess()是我在前端页面中写好的javascript function,此方法主要用于输出异常和上传成功后的图片地址
                context.Response.Write("fale|文件格式不正确");
            }
            //验证文件的大小
            if (file.ContentLength > 2 * 1024 * 1024)
            {
                //这里window.parent.uploadSuccess()是我在前端页面中写好的javascript function,此方法主要用于输出异常和上传成功后的图片地址 
                context.Response.Write("false|文件超过2M");
            }
            //开始上传
            file.SaveAs(imageUrl);
            //这里window.parent.uploadSuccess()是我在前端页面中写好的javascript function,此方法主要用于输出异常和上传成功后的图片地址
            //如果成功返回的数据是需要返回两个字符串，我在这里使用了|分隔  例： 成功信息|/Test/hello.jpg
            Image srcImage = (Image)new Bitmap(file.InputStream);
            context.Response.Write("true|images/" + groupid + "/" + imageName + ext + "|" + srcImage.Width.ToString() + "|" + srcImage.Height.ToString());
            //context.Response.End();
        }
        else
        {
            //上传失败
            context.Response.Write("false|未选择上传图片");
        }
    }

    private void Base64Img(HttpContext context, string groupid) {
        string data = context.Request.Form["data"];
        bool IsLog = false;
        if (context.Request.Form["islog"] != null)
            IsLog = bool.Parse(context.Request.Form["islog"]);
        if (data != null)
        {
            try
            {
                data = data.Split(',')[1];
                Image img = ToImage(data);
                DateTime dt = DateTime.Now;
                byte[] bytes = Convert.FromBase64String(data);
                MemoryStream stream = new MemoryStream(bytes);
                string strFileName = Guid.NewGuid().ToString() + ".jpg";
                string upPath = "/MobileManager/Image/" + groupid + "/" + dt.Year + "/" + dt.Month + "/";
                // 返回上传文件名
                Upload(stream, upPath, strFileName);
                // 图片访问路径
                string imgPath = System.Configuration.ConfigurationManager.AppSettings["HttpRootftpUrl"] + upPath + strFileName;
                imgPath = imgPath.Replace("//", "/").Replace("http:/", "http://");
                if (IsLog)
                {
                    if (img.Width >= 180)
                        ResizeImage(imgPath, 150, strFileName, ".jpg", upPath);
                }
                if (img.Width >= 260)
                    ResizeImage(imgPath, 240, strFileName, ".jpg", upPath);

                if (img.Width >= 500)
                    ResizeImage(imgPath, 480, strFileName, ".jpg", upPath);

                context.Response.Write("true|" + imgPath);
            }
            catch (Exception ex)
            {
                context.Response.Write("false|" + ex.Message);
            }
        }
        else
        {
            context.Response.Write("false|上传失败");
        }
    }
    
    private void UploadImg(HttpContext context, string groupid)
    {
        HttpPostedFile file = context.Request.Files["fileUp"];
        if (file != null)
        {
            try
            {
                string xscale = context.Request.Form["xscale"];
                string yscale = context.Request.Form["yscale"];
                
                string totalGraph = context.Request["totalGraph"];
                bool IsLog = false;
                if (context.Request.Form["islog"] != null)
                    IsLog = bool.Parse(context.Request.Form["islog"]);
                //string menberId = context.Request.Form["menberId"];
                string ext = Path.GetExtension(file.FileName);
                Stream fs = new MemoryStream();
                Bitmap destBitmap = null;
                // 目标图容器
                Rectangle destRect = new Rectangle();
                // 原图截取区域
                Rectangle srcRect = new Rectangle();
                System.Drawing.Imaging.ImageFormat iformat;

                Image srcImage = (Image)new Bitmap(file.InputStream);               // 原图

                if (!string.IsNullOrWhiteSpace(xscale) && !string.IsNullOrWhiteSpace(yscale))
                {
                    
                    int i_xscale = Convert.ToInt32(xscale),                             // 裁切横向比例尺
                        i_yscale = Convert.ToInt32(yscale),                             // 裁切纵向比例尺
                        i_x = Convert.ToInt32(context.Request.Form["x"]),               // 裁切开始横坐标
                        i_y = Convert.ToInt32(context.Request.Form["y"]),               // 裁切开始纵坐标
                        i_w = Convert.ToInt32(context.Request.Form["w"]),               // 裁切宽度
                        i_h = Convert.ToInt32(context.Request.Form["h"]),               // 裁切高度
                        i_boundx = Convert.ToInt32(context.Request.Form["boundx"]),     // 页面图片初始宽度
                        i_boundy = Convert.ToInt32(context.Request.Form["boundy"]),     // 页面图片初始高度
                        s_w = srcImage.Width,                                           // 图片原始宽度
                        s_h = srcImage.Height;                                          // 图片原始高度
                    double scale = 1,                                                   // 实际比例
                        s_scale = 1;                                                    // 伸缩比例

                    // 页面显示图片时，最大宽度和高度为400，所以用400进行比较
                    if (s_w > 400 || s_h > 400)
                    {
                        // 需要计算伸缩比例
                        if (s_w >= s_h)
                        {
                            // 图片宽度大于高度，按宽度伸缩比例计算
                            s_scale = double.Parse(i_boundx.ToString()) / 400.00;
                            s_scale = double.Parse(s_scale.ToString("#0.00"));
                            // 计算实际比例
                            scale = double.Parse(s_w.ToString()) / 400.00;
                            scale = double.Parse(scale.ToString("#0.00"));
                        }
                        else
                        {
                            // 图片高度大于宽度，按高度伸缩比例计算
                            s_scale = double.Parse(i_boundy.ToString()) / 400.00;
                            s_scale = double.Parse(s_scale.ToString("#0.00"));
                            // 计算实际比例
                            scale = double.Parse(s_h.ToString()) / 400.00;
                            scale = double.Parse(scale.ToString("#0.00"));
                        }
                    }

                    // 计算实际的裁切开始位置和宽高
                    int t_x = Convert.ToInt32(i_x / s_scale * scale),
                        t_y = Convert.ToInt32(i_y / s_scale * scale),
                        t_w = Convert.ToInt32(i_w / s_scale * scale),
                        t_h = Convert.ToInt32(i_h / s_scale * scale);
                    
                    if (totalGraph != "1")
                    {
                        // 目标图
                        destBitmap = new Bitmap(t_w, t_h);
                        // 目标图容器
                        destRect = new Rectangle(0, 0, t_w, t_h);
                        // 原图截取区域
                        srcRect = new Rectangle(t_x, t_y, t_w, t_h);
                    }
                    else 
                    {
                        // 目标图
                        destBitmap = new Bitmap(s_w, s_h);
                        // 目标图容器
                        destRect = new Rectangle(0, 0, s_w, s_h);
                        // 原图截取区域
                        srcRect = new Rectangle(0, 0, s_w, s_h);
                    }
                    
                }
                else
                {
                    // 目标图
                    destBitmap = new Bitmap(srcImage.Width, srcImage.Height);
                    // 目标图容器
                    destRect = new Rectangle(0, 0, srcImage.Width, srcImage.Height);
                    // 原图截取区域
                    srcRect = new Rectangle(0, 0, srcImage.Width, srcImage.Height);
                }
                
                //从指定的Image对象创建新Graphics对象
                Graphics graphics = Graphics.FromImage(destBitmap);
                switch (ext.ToUpper())
                {
                    case ".GIF":
                        iformat = System.Drawing.Imaging.ImageFormat.Gif;
                        graphics.Clear(Color.Transparent);
                        break;
                    case ".JPG":
                    case ".JPEG":
                        iformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                        graphics.Clear(Color.White);
                        break;
                    case ".PNG":
                        iformat = System.Drawing.Imaging.ImageFormat.Png;
                        graphics.Clear(Color.Transparent);
                        break;
                    case ".BMP":
                        iformat = System.Drawing.Imaging.ImageFormat.Bmp;
                        graphics.Clear(Color.White);
                        break;
                    default:
                        iformat = System.Drawing.Imaging.ImageFormat.Png;
                        graphics.Clear(Color.Transparent);
                        break;
                }
                //设置质量
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                //在指定位置并且按指定大小绘制原图片对象
                graphics.DrawImage(srcImage, destRect, srcRect, GraphicsUnit.Pixel);

                if (ext.ToUpper() == ".JPG" || ext.ToUpper() == ".JPEG")
                {
                    EncoderParameters ep = new EncoderParameters(2);
                    ep.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 70L);
                    ep.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.ColorDepth, 48 + 24L);
                    ImageCodecInfo ici = this.getImageCoderInfo("image/jpeg");
                    destBitmap.Save(fs, ici, ep);
                }
                else
                {
                    destBitmap.Save(fs, iformat);
                }

                // 上传文件到FTP
                // 上传路径
                DateTime dt = DateTime.Now;
                string strFileName = Guid.NewGuid().ToString() + ext;
                string upPath = "/" + groupid + "/";
                // 返回上传文件名
                 Upload(fs, upPath, strFileName);
                // 图片访问路径
                 string imgPath = System.Configuration.ConfigurationManager.AppSettings["HttpRootftpUrl"] + upPath + strFileName;
                imgPath = imgPath.Replace("//", "/").Replace("http:/", "http://");
                if (IsLog)
                {
                    if (destBitmap.Width >= 180)
                        ResizeImage(imgPath, 150, strFileName, ext, upPath);
                }
                if (destBitmap.Width >= 260)
                    ResizeImage(imgPath, 240, strFileName, ext, upPath);
                
                if(destBitmap.Width>=500)
                    ResizeImage(imgPath, 480, strFileName, ext, upPath);
                
                context.Response.Write("true|" + imgPath);
            }
            catch (Exception ex)
            {
                context.Response.Write("false|" + ex.Message);
            }
        }
        else
        {
            context.Response.Write("false|上传失败");
        }
    }
    /// <summary>
    /// 等比压缩图片，返回固定大小并居中
    /// </summary>
    /// <param name="mg"></param>
    /// <param name="newSize"></param>
    /// <returns></returns>
    public void ResizeImage(string serverImagePath, int Width, string strFileName, string ext, string thumbnailImagePath)
    {
        System.Net.WebRequest webreq = System.Net.WebRequest.Create(serverImagePath);
        System.Net.WebResponse webres = webreq.GetResponse();
        System.Drawing.Image serverImage = null;
        using (System.IO.Stream stream = webres.GetResponseStream())
        {
            serverImage = Image.FromStream(stream);
        }
        Stream fs = new MemoryStream();
        System.Drawing.Image mg = new System.Drawing.Bitmap(serverImage.Width, serverImage.Height);
        double ratio;//压缩比
        int myWidth;
        int myHeight;
        double calcHeight;
        ratio = Convert.ToDouble(mg.Width) / Convert.ToDouble(Width);
        calcHeight = mg.Height / ratio;
        string[] heightArr = calcHeight.ToString().Split('.');

        if (heightArr.Length == 1)
        {
            myHeight = (int)Math.Floor(calcHeight);
        }
        else
        {
            myHeight = Convert.ToInt32(heightArr[1].Substring(0, 1)) < 5 ? (int)Math.Floor(calcHeight) : (int)Math.Ceiling(calcHeight);
        }
        Bitmap bp = new Bitmap(Width, myHeight);
        System.Drawing.Graphics g = Graphics.FromImage(bp);
        
        ////设置高质量插值法
        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
        ////设置高质量,低速度呈现平滑程度
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        ////清空画布并以透明背景色填充
        g.Clear(System.Drawing.Color.White);
        Rectangle rect = new Rectangle(0, 0, Width, myHeight);
        g.DrawImage(serverImage, rect, 0, 0, mg.Width, mg.Height, GraphicsUnit.Pixel);
        ImageCodecInfo ici = this.getImageCoderInfo("image/jpeg");
        EncoderParameters eptS = new EncoderParameters(2);
        eptS.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 70L);
        eptS.Param[1] = new EncoderParameter(System.Drawing.Imaging.Encoder.ColorDepth, 48 + 24L);
        bp.Save(fs, ici, eptS);
        try
        {
            string FileName = strFileName + "_" + Width + "x" + myHeight + ext;
            Upload(fs, thumbnailImagePath, FileName);
            string imgPath = System.Configuration.ConfigurationManager.AppSettings["HttpRootftpUrl"] + thumbnailImagePath + FileName;
            imgPath = imgPath.Replace("//", "/").Replace("http:/", "http://");
        }
        catch (System.Exception e)
        {
            throw e;
        }
        finally
        {
        }
    }
    
    
    

    /// <summary>
    /// 获取图片编码类型信息
    /// </summary>
    /// <param name="coderType">编码类型</param>
    /// <returns>ImageCodecInfo</returns>
    private ImageCodecInfo getImageCoderInfo(string coderType)
    {
        ImageCodecInfo[] iciS = ImageCodecInfo.GetImageEncoders();
        ImageCodecInfo retIci = null;
        foreach (ImageCodecInfo ici in iciS)
        {
            if (ici.MimeType.Equals(coderType))
                retIci = ici;
        }
        return retIci;
    }

    public void Upload(Stream pStream, string FolderName, string pExtname)
    {
        this.MakeDir(FolderName);
        //string strFileName = Guid.NewGuid().ToString() + pExtname;
        string path = "ftp://" + this.ftpServerIP + FolderName + pExtname;
        this.Connect(path);
        this.reqFTP.KeepAlive = false;
        this.reqFTP.Method = "STOR";
        this.reqFTP.ContentLength = pStream.Length;
        int count = 0x800;
        try
        {
            pStream.Position = 0;
            byte[] buffer = new byte[count];
            Stream requestStream = this.reqFTP.GetRequestStream();
            for (int i = pStream.Read(buffer, 0, count); i != 0; i = pStream.Read(buffer, 0, count))
            {
                requestStream.Write(buffer, 0, i);
            }
            requestStream.Close();
            pStream.Close();
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }

    public void Upload(string FolderName, string Filename)
    {
        this.MakeDir(FolderName);
        FileInfo info = new FileInfo(Filename);
        string path = "ftp://" + this.ftpServerIP + "/" + FolderName + "/" + info.Name;
        this.Connect(path);
        this.reqFTP.KeepAlive = false;
        this.reqFTP.Method = "STOR";
        this.reqFTP.ContentLength = info.Length;
        int count = 0x800;
        byte[] buffer = new byte[count];
        FileStream stream = info.OpenRead();
        try
        {
            Stream requestStream = this.reqFTP.GetRequestStream();
            for (int i = stream.Read(buffer, 0, count); i != 0; i = stream.Read(buffer, 0, count))
            {
                requestStream.Write(buffer, 0, i);
            }
            requestStream.Close();
            stream.Close();
        }
        catch (Exception exception)
        {
            throw exception;
        }
    }

    public void MakeDir(string dirName)
    {
        string[] strArray = dirName.Split(new char[] { '/' });
        string str = "";
        for (int i = 0; i < strArray.Length; i++)
        {
            str = str + strArray[i].ToString() + "/";
            string path = "ftp://" + this.ftpServerIP + "/" + str;
            try
            {
                this.Connect(path);
                this.reqFTP.Method = "MKD";
                ((FtpWebResponse)this.reqFTP.GetResponse()).Close();
            }
            catch
            {
            }
        }
    }
    private void Connect(string path)
    {
        this.reqFTP = (FtpWebRequest)WebRequest.Create(new Uri(path));
        this.reqFTP.UseBinary = true;
        this.reqFTP.Credentials = new NetworkCredential(this.ftpUserID, this.ftpPassword);
    }

    /// 将图片数据转换为Base64字符串 
    public string ToBase64(Image img)
    {
        System.Runtime.Serialization.Formatters.Binary.BinaryFormatter binFormatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
        MemoryStream memStream = new MemoryStream();
        binFormatter.Serialize(memStream, img);
        byte[] bytes = memStream.GetBuffer();
        string base64 = Convert.ToBase64String(bytes);
        return base64;
    }
    //将Base64字符串转化为图片
    private Image ToImage(string base64)
    {
        byte[] bytes = Convert.FromBase64String(base64); 
        MemoryStream memoryStream = new MemoryStream(bytes, 0, bytes.Length);
        memoryStream.Write(bytes, 0, bytes.Length);
        //转成图片
        Image image = Image.FromStream(memoryStream);
        return image;
    }    
    
    public bool IsReusable {
        get {
            return false;
        }
    }

}