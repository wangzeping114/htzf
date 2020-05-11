<%@ WebHandler Language="C#" Class="CreateTempImage" %>

using System;
using System.Web;
using System.IO;
using System.Drawing;
using System.Text;
using System.Collections;

public class CreateTempImage : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        context.Response.ContentType = "text/plain";
        Hashtable res = new Hashtable();
        try
        {
            //获取当前Post过来的file集合对象,在这里我只获取了<input type='file' name='fileUp'/>的文件控件
            string action = context.Request["action"];
            System.Collections.Specialized.NameValueCollection form = context.Request.Form;

            
                switch (action)
                { 
                    case "temp":
                        CreateTemp(context);
                        break;
                    case "upload":
                        UploadImg(context);
                        break;
                    default:
                        context.Response.Write("false|未知操作");
                        break;
                }
        }
        catch (Exception e)
        {
            //上传失败 
            context.Response.Write("false|上传失败"+e.Message);
        }
    }

    private void CreateTemp(HttpContext context)
    {
        HttpPostedFile file = context.Request.Files["fileUp"];
        if (file != null)
        {
            //当前文件上传的目录
            string path = context.Server.MapPath("~/UpImg/");
            
            // 判断集团目录是否存在
            if (!Directory.Exists(path))
            {
                // 不存在就创建
                Directory.CreateDirectory(path );
            }
            else
            { 
                // 存在就将目录里的临时图片全部删除
                foreach (string tempImg in Directory.GetFiles(path))
                {
                    if (File.Exists(tempImg) && IsImage(tempImg))
                    {
                        File.Delete(tempImg);
                    }
                }
            }
            // 将groupid拼接入path
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
            
            context.Response.Write("true|images/" + imageName + ext + "|" + srcImage.Width.ToString() + "|" + srcImage.Height.ToString());
            //context.Response.End();
        }
        else
        {
            //上传失败
            context.Response.Write("false|未选择上传图片");
        }
    }

    private void UploadImg(HttpContext context)
    {
        HttpPostedFile file = context.Request.Files["fileUp"];
        if (file != null)
        {
            string path = context.Server.MapPath("~/UpImg/");
            
            // 判断集团目录是否存在
            if (!Directory.Exists(path))
            {
                // 不存在就创建
                Directory.CreateDirectory(path );
            }
            else
            { 
                // 存在就将目录里的临时图片全部删除
                foreach (string tempImg in Directory.GetFiles(path))
                {
                    if (File.Exists(tempImg) && IsImage(tempImg))
                    {
                        File.Delete(tempImg);
                    }
                }
            }
            string imageName = Guid.NewGuid().ToString().Replace("-", "");
            string imageUrl = path + imageName;
            string ext = Path.GetExtension(file.FileName).ToLower();
            imageUrl += ext;
            try
            {
                string xscale = context.Request.Form["xscale"];
                string yscale = context.Request.Form["yscale"];
                Stream fs = new MemoryStream();
                System.Drawing.Imaging.ImageFormat iformat;
                switch (ext.ToUpper())
                {
                    case ".GIF":
                        iformat = System.Drawing.Imaging.ImageFormat.Gif;
                        break;
                    case ".JPG":
                    case ".JPEG":
                        iformat = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case ".PNG":
                        iformat = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                    case ".BMP":
                        iformat = System.Drawing.Imaging.ImageFormat.Bmp;
                        break;
                    default:
                        iformat = System.Drawing.Imaging.ImageFormat.Png;
                        break;
                }

                if (!string.IsNullOrWhiteSpace(xscale) && !string.IsNullOrWhiteSpace(yscale))
                {

                    Image srcImage = (Image)new Bitmap(file.InputStream);               // 原图
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

                    // 目标图
                    Bitmap destBitmap = new Bitmap(t_w, t_h);
                    // 目标图容器
                    Rectangle destRect = new Rectangle(0, 0, t_w, t_h);
                    // 原图截取区域
                    Rectangle srcRect = new Rectangle(t_x, t_y, t_w, t_h);
                    //从指定的Image对象创建新Graphics对象
                    Graphics graphics = Graphics.FromImage(destBitmap);
                    //清除整个绘图面并以白背景色填充
                    graphics.Clear(Color.White);
                    //设置质量
                    graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
                    //在指定位置并且按指定大小绘制原图片对象
                    graphics.DrawImage(srcImage, destRect, srcRect, GraphicsUnit.Pixel);
                    destBitmap.Save(imageUrl, iformat);
                    destBitmap.Save(fs, iformat);
                }
                else
                {
                    file.SaveAs(imageUrl);
                }
                
                // 图片访问路径
                string imgPath = FuncUtility.HttpHelp.GetCurrentHttpSite() + "/UpImg/" + imageName + ext;
                context.Response.Write("true|" + imgPath);
            }
            catch (Exception ex)
            {
                FuncUtility.Utils.WriteErrLogToTxt("图片上传失败", ex);
            }
        }
        else
        {
            context.Response.Write("false|上传失败");
        }
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

    #region -- 判断文件是否为图片 --
    /// <param name="path">文件的完整路径</param>
    /// <returns>返回结果</returns>
    public Boolean IsImage(string path)
    {
        try
        {
            System.Drawing.Image img = System.Drawing.Image.FromFile(path);
            img.Dispose();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    #endregion

}