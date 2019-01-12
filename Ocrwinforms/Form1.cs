using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Tesseract;

namespace Ocrwinforms
{
    public partial class Form1 : Form
    {
         
        public Form1()
        {
            InitializeComponent();
            //Tesseract ocr = new Tesseract("","tur",OcrEngineMode.TesseractCubeCombined);
            var engine = new TesseractEngine("D:\\TumProjeler\\Ocrwinforms\\Ocrwinforms\\tessdata", "tur",EngineMode.TesseractOnly);
           // Tesseract ocr = new Tesseract("D:\\TumProjeler\\Ocrwinforms\\Ocrwinforms\\tessdata", "tur", OcrEngineMode.Default);

            DirectoryInfo d = new DirectoryInfo("D:\\TumProjeler\\Ocrwinforms\\Ocrwinforms\\test");//Assuming Test is your Folder
            FileInfo[] Files = d.GetFiles("*.png"); //Getting Text files
            string str = "";
            foreach (FileInfo file in Files)
            {
                var img = new Bitmap(file.DirectoryName+"\\"+file.Name);
                //Image<Bgr, byte> image = new Image<Bgr, byte>(img);
                //ocr.SetImage(image);
                //ocr.ProcessPage(image);
               // engine.Dispose();
                tb1.Text += engine.Process(img).GetText();
                //engine.Dispose();
                break;

            }

           
            
        }
    }
}
