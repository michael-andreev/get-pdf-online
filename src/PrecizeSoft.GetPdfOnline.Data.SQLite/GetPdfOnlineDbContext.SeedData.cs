using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using PrecizeSoft.GetPdfOnline.Model;

namespace PrecizeSoft.GetPdfOnline.Data.SQLite
{
    public partial class GetPdfOnlineDbContext : ISeedDatabase
    {
        private IEnumerable<string> LODoc = new List<string>()
            { ".602", ".abw", ".cwk", ".doc", ".docm", ".docx", ".dot", ".dotm", ".dotx", ".fb2", ".fodt", ".htm", ".html",
            ".hwp", ".lrf", ".lwp", ".mcw", ".mw", ".mwd", ".nx^d", ".odt", ".ott", ".pages", ".pdb", ".rtf", ".sdw", ".stw",
            ".sxw", ".txt", ".uof", ".uot", ".wn", ".wpd", ".wps", ".wpt", ".wri", ".xml", ".zabw", ".zip" };

        private IEnumerable<string> LOCalc = new List<string>()
            { ".123", ".csv", ".cwk", ".dbf", ".dif", ".et", ".ett", ".fods", ".gnm", ".gnumeric", ".htm", ".html",
            ".numbers", ".ods", ".ots", ".rtf", ".sdc", ".slk", ".stc", ".sxc", ".sylk", ".uof", ".uos", ".wb2", ".wdb",
            ".wk1", ".wk3", ".wks", ".wps", ".wq1", ".wq2", ".xlc", ".xlk", ".xlm", ".xls", ".xlsb", ".xlsm", ".xlsx",
            ".xlt", ".xltm", ".xltx", ".xlw", ".xml" };

        private IEnumerable<string> LOImpress = new List<string>()
            { ".cgm", ".cwk", ".dps", ".dpt", ".fodp", ".key", ".odg", ".odp", ".otp", ".pot", ".potm", ".potx", ".pps",
            ".ppsx", ".ppt", ".pptm", ".pptx", ".sti", ".sxd", ".sxi", ".uof", ".uop", ".xml" };

        private IEnumerable<string> LODraw = new List<string>()
            { ".bmp", ".cdr", ".cmx", ".cwk", ".dxf", ".emf", ".eps", ".fh", ".fh1", ".fh10", ".fh11", ".fh2",
            ".fh3", ".fh4", ".fh5", ".fh6", ".fh7", ".fh8", ".fh9", ".fodg", ".gif", ".jfif", ".jif", ".jpe",
            ".jpeg", ".jpg", ".met", ".mov", ".odg", ".odg", ".otg", ".p65", ".pbm", ".pcd", ".pct", ".pcx",
            ".pgm", ".pict", ".pm", ".pm6", ".pmd", ".png", ".ppm", ".psd", ".pub", ".ras", ".sda", ".sgf",
            ".sgv", ".std", ".svg", ".svgz", ".svm", ".sxd", ".tga", ".tif", ".tiff", ".vdx", ".vsd", ".vsdm",
            ".vsdx", ".wmf", ".wpg", ".xbm", ".xml", ".xpm", ".zmf" };

        private IEnumerable<string> MSODoc = new List<string>()
            { ".docx", ".doc", ".docm", ".dot", ".dotm", ".dotx", ".odt", ".wbk", ".wiz", ".rtf"};

        private IEnumerable<string> MSOExcel = new List<string>()
            { ".csv", ".dqy", ".iqy", ".odc", ".ods", ".oqy", ".rqy", ".slk", ".xla", ".xlam", ".xld",
                ".xlk", ".xll", ".xlm", ".xls", ".xlsb", ".xlshtml", ".xlsm", ".xlsmhtml", ".xlsx", ".xlt",
                ".xlthtml", ".xltm", ".xltx", ".xlw", ".xlxml"};

        private IEnumerable<string> MSOPP = new List<string>()
            { ".odp", ".pot", ".potm", ".potx", ".ppa", ".ppam", ".pps", ".ppsm", ".ppsx", ".ppt", ".pptm", ".pptx", ".pwz" };

        private IEnumerable<string> MSOVisio = new List<string>()
                { ".vdw", ".vdx", ".vsd", ".vsdm", ".vsdx", ".vss", ".vssm", ".vssx", ".vst", ".vstm", ".vstx", ".vsx", ".vtx" };

        private IEnumerable<string> Images = new List<string>()
            { ".aai", ".art", ".arw", ".avi", ".avs", ".bpg", ".bmp", ".bmp2", ".bmp3", ".cals",
            ".cgm", ".cin", ".cmyk", ".cmyka", ".cr2", ".crw", ".cur", ".cut", ".dcm", ".dcr",
            ".dcx", ".dds", ".dib", ".djvu", ".dng", ".dot", ".dpx", ".emf", ".epi", ".eps",
            ".eps2", ".eps3", ".epsf", ".epsi", ".ept", ".exr", ".fax", ".fig", ".fits", ".fpx",
            ".gif", ".gplt", ".gray", ".hdr", ".hpgl", ".hrz", ".ico", ".jbig", ".jng", ".jp2",
            ".jpt", ".j2c", ".j2k", ".jpeg", ".jpg", ".jxr", ".man", ".mat", ".miff", ".mono",
            ".mng", ".m2v", ".mpeg", ".mpc", ".mpr", ".mrw", ".msl", ".mtv", ".mvg", ".nef",
            ".orf", ".otb", ".p7", ".palm", ".pam", ".pbm", ".pcd", ".pcds", ".pcl", ".pcx",
            ".pdb", ".pef", ".pfa", ".pfb", ".pfm", ".pgm", ".picon", ".pict", ".pix", ".png",
            ".png8", ".png00", ".png24", ".png32", ".png48", ".png64", ".pnm", ".ppm", ".ps",
            ".ps2", ".ps3", ".psb", ".psd", ".ptif", ".pwp", ".rad", ".raf", ".rgb", ".rgba",
            ".rfg", ".rla", ".rle", ".sct", ".sfw", ".sgi", ".sid", ".mrsid", ".sun", ".svg",
            ".tga", ".tiff", ".tim", ".ttf", ".uil", ".uyvy", ".vicar", ".viff", ".wbmp", ".wdp",
            ".webp", ".wmf", ".wpg", ".x", ".xbm", ".xcf", ".xpm", ".xwd", ".x3f", ".ycbcr",
            ".ycbcra", ".yuv" };

        public void Seed()
        {
            this.SeedDirectories();
            this.SeedTestData();
        }

        public void SeedDirectories()
        {
            this.SeedFileCategories();
            this.SeedFileTypes();
            this.SeedConvertResultTypes();
        }

        public void SeedFileCategories()
        {
            if (!this.FileCategories.Any())
            {
                this.FileCategories.AddRange(
                    new FileCategory { FileCategoryId = 10, FileCategoryCode = "Document" },
                    new FileCategory { FileCategoryId = 20, FileCategoryCode = "Spreadsheet" },
                    new FileCategory { FileCategoryId = 30, FileCategoryCode = "Presentation" },
                    new FileCategory { FileCategoryId = 40, FileCategoryCode = "Diagram" },
                    new FileCategory { FileCategoryId = 50, FileCategoryCode = "Image" }
                    );
            }
        }

        public void SeedFileTypes()
        {
            /*int i;

            i = 1001;
            var docs = this.LODoc.Concat(this.MSODoc).Distinct().OrderBy(p => p).Select(p => new FileType { FileTypeId = i++, FileCategoryId = 10, FileExtension = p });
            this.FileTypes.AddRange(docs);

            i = 2001;
            var calc = this.LOCalc.Concat(this.MSOExcel).Distinct().OrderBy(p => p).Select(p => new FileType { FileTypeId = i++, FileCategoryId = 20, FileExtension = p });
            this.FileTypes.AddRange(calc);

            i = 3001;
            var slides = this.LOImpress.Concat(this.MSOPP).Distinct().OrderBy(p => p).Select(p => new FileType { FileTypeId = i++, FileCategoryId = 30, FileExtension = p });
            this.FileTypes.AddRange(slides);

            i = 4001;
            var diagrams = this.LODraw.Concat(this.MSOVisio).Distinct().OrderBy(p => p).Select(p => new FileType { FileTypeId = i++, FileCategoryId = 40, FileExtension = p });
            this.FileTypes.AddRange(diagrams);

            i = 5001;
            var images = this.Images.OrderBy(p => p).Select(p => new FileType { FileTypeId = i++, FileCategoryId = 50, FileExtension = p });
            this.FileTypes.AddRange(images);*/

            this.FileTypes.AddRange(
                new FileType { FileTypeId = 1001, FileCategoryId = 10, FileExtension = ".602" },
                new FileType { FileTypeId = 1002, FileCategoryId = 10, FileExtension = ".abw" },
                new FileType { FileTypeId = 1003, FileCategoryId = 10, FileExtension = ".cwk" },
                new FileType { FileTypeId = 1004, FileCategoryId = 10, FileExtension = ".doc" },
                new FileType { FileTypeId = 1005, FileCategoryId = 10, FileExtension = ".docm" },
                new FileType { FileTypeId = 1006, FileCategoryId = 10, FileExtension = ".docx" },
                new FileType { FileTypeId = 1007, FileCategoryId = 10, FileExtension = ".dot" },
                new FileType { FileTypeId = 1008, FileCategoryId = 10, FileExtension = ".dotm" },
                new FileType { FileTypeId = 1009, FileCategoryId = 10, FileExtension = ".dotx" },
                new FileType { FileTypeId = 1010, FileCategoryId = 10, FileExtension = ".fb2" },
                new FileType { FileTypeId = 1011, FileCategoryId = 10, FileExtension = ".fodt" },
                new FileType { FileTypeId = 1012, FileCategoryId = 10, FileExtension = ".htm" },
                new FileType { FileTypeId = 1013, FileCategoryId = 10, FileExtension = ".html" },
                new FileType { FileTypeId = 1014, FileCategoryId = 10, FileExtension = ".hwp" },
                new FileType { FileTypeId = 1015, FileCategoryId = 10, FileExtension = ".lrf" },
                new FileType { FileTypeId = 1016, FileCategoryId = 10, FileExtension = ".lwp" },
                new FileType { FileTypeId = 1017, FileCategoryId = 10, FileExtension = ".mcw" },
                new FileType { FileTypeId = 1018, FileCategoryId = 10, FileExtension = ".mw" },
                new FileType { FileTypeId = 1019, FileCategoryId = 10, FileExtension = ".mwd" },
                new FileType { FileTypeId = 1020, FileCategoryId = 10, FileExtension = ".nx^d" },
                new FileType { FileTypeId = 1021, FileCategoryId = 10, FileExtension = ".odt" },
                new FileType { FileTypeId = 1022, FileCategoryId = 10, FileExtension = ".ott" },
                new FileType { FileTypeId = 1023, FileCategoryId = 10, FileExtension = ".pages" },
                new FileType { FileTypeId = 1024, FileCategoryId = 10, FileExtension = ".pdb" },
                new FileType { FileTypeId = 1025, FileCategoryId = 10, FileExtension = ".rtf" },
                new FileType { FileTypeId = 1026, FileCategoryId = 10, FileExtension = ".sdw" },
                new FileType { FileTypeId = 1027, FileCategoryId = 10, FileExtension = ".stw" },
                new FileType { FileTypeId = 1028, FileCategoryId = 10, FileExtension = ".sxw" },
                new FileType { FileTypeId = 1029, FileCategoryId = 10, FileExtension = ".txt" },
                new FileType { FileTypeId = 1030, FileCategoryId = 10, FileExtension = ".uof" },
                new FileType { FileTypeId = 1031, FileCategoryId = 10, FileExtension = ".uot" },
                new FileType { FileTypeId = 1032, FileCategoryId = 10, FileExtension = ".wbk" },
                new FileType { FileTypeId = 1033, FileCategoryId = 10, FileExtension = ".wiz" },
                new FileType { FileTypeId = 1034, FileCategoryId = 10, FileExtension = ".wn" },
                new FileType { FileTypeId = 1035, FileCategoryId = 10, FileExtension = ".wpd" },
                new FileType { FileTypeId = 1036, FileCategoryId = 10, FileExtension = ".wps" },
                new FileType { FileTypeId = 1037, FileCategoryId = 10, FileExtension = ".wpt" },
                new FileType { FileTypeId = 1038, FileCategoryId = 10, FileExtension = ".wri" },
                new FileType { FileTypeId = 1039, FileCategoryId = 10, FileExtension = ".xml" },
                new FileType { FileTypeId = 1040, FileCategoryId = 10, FileExtension = ".zabw" },
                new FileType { FileTypeId = 1041, FileCategoryId = 10, FileExtension = ".zip" },
                new FileType { FileTypeId = 2001, FileCategoryId = 20, FileExtension = ".123" },
                new FileType { FileTypeId = 2002, FileCategoryId = 20, FileExtension = ".csv" },
                new FileType { FileTypeId = 2004, FileCategoryId = 20, FileExtension = ".dbf" },
                new FileType { FileTypeId = 2005, FileCategoryId = 20, FileExtension = ".dif" },
                new FileType { FileTypeId = 2006, FileCategoryId = 20, FileExtension = ".dqy" },
                new FileType { FileTypeId = 2007, FileCategoryId = 20, FileExtension = ".et" },
                new FileType { FileTypeId = 2008, FileCategoryId = 20, FileExtension = ".ett" },
                new FileType { FileTypeId = 2009, FileCategoryId = 20, FileExtension = ".fods" },
                new FileType { FileTypeId = 2010, FileCategoryId = 20, FileExtension = ".gnm" },
                new FileType { FileTypeId = 2011, FileCategoryId = 20, FileExtension = ".gnumeric" },
                new FileType { FileTypeId = 2014, FileCategoryId = 20, FileExtension = ".iqy" },
                new FileType { FileTypeId = 2015, FileCategoryId = 20, FileExtension = ".numbers" },
                new FileType { FileTypeId = 2016, FileCategoryId = 20, FileExtension = ".odc" },
                new FileType { FileTypeId = 2017, FileCategoryId = 20, FileExtension = ".ods" },
                new FileType { FileTypeId = 2018, FileCategoryId = 20, FileExtension = ".oqy" },
                new FileType { FileTypeId = 2019, FileCategoryId = 20, FileExtension = ".ots" },
                new FileType { FileTypeId = 2020, FileCategoryId = 20, FileExtension = ".rqy" },
                new FileType { FileTypeId = 2022, FileCategoryId = 20, FileExtension = ".sdc" },
                new FileType { FileTypeId = 2023, FileCategoryId = 20, FileExtension = ".slk" },
                new FileType { FileTypeId = 2024, FileCategoryId = 20, FileExtension = ".stc" },
                new FileType { FileTypeId = 2025, FileCategoryId = 20, FileExtension = ".sxc" },
                new FileType { FileTypeId = 2026, FileCategoryId = 20, FileExtension = ".sylk" },
                new FileType { FileTypeId = 2028, FileCategoryId = 20, FileExtension = ".uos" },
                new FileType { FileTypeId = 2029, FileCategoryId = 20, FileExtension = ".wb2" },
                new FileType { FileTypeId = 2030, FileCategoryId = 20, FileExtension = ".wdb" },
                new FileType { FileTypeId = 2031, FileCategoryId = 20, FileExtension = ".wk1" },
                new FileType { FileTypeId = 2032, FileCategoryId = 20, FileExtension = ".wk3" },
                new FileType { FileTypeId = 2033, FileCategoryId = 20, FileExtension = ".wks" },
                new FileType { FileTypeId = 2035, FileCategoryId = 20, FileExtension = ".wq1" },
                new FileType { FileTypeId = 2036, FileCategoryId = 20, FileExtension = ".wq2" },
                new FileType { FileTypeId = 2037, FileCategoryId = 20, FileExtension = ".xla" },
                new FileType { FileTypeId = 2038, FileCategoryId = 20, FileExtension = ".xlam" },
                new FileType { FileTypeId = 2039, FileCategoryId = 20, FileExtension = ".xlc" },
                new FileType { FileTypeId = 2040, FileCategoryId = 20, FileExtension = ".xld" },
                new FileType { FileTypeId = 2041, FileCategoryId = 20, FileExtension = ".xlk" },
                new FileType { FileTypeId = 2042, FileCategoryId = 20, FileExtension = ".xll" },
                new FileType { FileTypeId = 2043, FileCategoryId = 20, FileExtension = ".xlm" },
                new FileType { FileTypeId = 2044, FileCategoryId = 20, FileExtension = ".xls" },
                new FileType { FileTypeId = 2045, FileCategoryId = 20, FileExtension = ".xlsb" },
                new FileType { FileTypeId = 2046, FileCategoryId = 20, FileExtension = ".xlshtml" },
                new FileType { FileTypeId = 2047, FileCategoryId = 20, FileExtension = ".xlsm" },
                new FileType { FileTypeId = 2048, FileCategoryId = 20, FileExtension = ".xlsmhtml" },
                new FileType { FileTypeId = 2049, FileCategoryId = 20, FileExtension = ".xlsx" },
                new FileType { FileTypeId = 2050, FileCategoryId = 20, FileExtension = ".xlt" },
                new FileType { FileTypeId = 2051, FileCategoryId = 20, FileExtension = ".xlthtml" },
                new FileType { FileTypeId = 2052, FileCategoryId = 20, FileExtension = ".xltm" },
                new FileType { FileTypeId = 2053, FileCategoryId = 20, FileExtension = ".xltx" },
                new FileType { FileTypeId = 2054, FileCategoryId = 20, FileExtension = ".xlw" },
                new FileType { FileTypeId = 2055, FileCategoryId = 20, FileExtension = ".xlxml" },
                new FileType { FileTypeId = 3003, FileCategoryId = 30, FileExtension = ".dps" },
                new FileType { FileTypeId = 3004, FileCategoryId = 30, FileExtension = ".dpt" },
                new FileType { FileTypeId = 3005, FileCategoryId = 30, FileExtension = ".fodp" },
                new FileType { FileTypeId = 3006, FileCategoryId = 30, FileExtension = ".key" },
                new FileType { FileTypeId = 3008, FileCategoryId = 30, FileExtension = ".odp" },
                new FileType { FileTypeId = 3009, FileCategoryId = 30, FileExtension = ".otp" },
                new FileType { FileTypeId = 3010, FileCategoryId = 30, FileExtension = ".pot" },
                new FileType { FileTypeId = 3011, FileCategoryId = 30, FileExtension = ".potm" },
                new FileType { FileTypeId = 3012, FileCategoryId = 30, FileExtension = ".potx" },
                new FileType { FileTypeId = 3013, FileCategoryId = 30, FileExtension = ".ppa" },
                new FileType { FileTypeId = 3014, FileCategoryId = 30, FileExtension = ".ppam" },
                new FileType { FileTypeId = 3015, FileCategoryId = 30, FileExtension = ".pps" },
                new FileType { FileTypeId = 3016, FileCategoryId = 30, FileExtension = ".ppsm" },
                new FileType { FileTypeId = 3017, FileCategoryId = 30, FileExtension = ".ppsx" },
                new FileType { FileTypeId = 3018, FileCategoryId = 30, FileExtension = ".ppt" },
                new FileType { FileTypeId = 3019, FileCategoryId = 30, FileExtension = ".pptm" },
                new FileType { FileTypeId = 3020, FileCategoryId = 30, FileExtension = ".pptx" },
                new FileType { FileTypeId = 3021, FileCategoryId = 30, FileExtension = ".pwz" },
                new FileType { FileTypeId = 3022, FileCategoryId = 30, FileExtension = ".sti" },
                new FileType { FileTypeId = 3024, FileCategoryId = 30, FileExtension = ".sxi" },
                new FileType { FileTypeId = 3026, FileCategoryId = 30, FileExtension = ".uop" },
                new FileType { FileTypeId = 4002, FileCategoryId = 40, FileExtension = ".cdr" },
                new FileType { FileTypeId = 4003, FileCategoryId = 40, FileExtension = ".cmx" },
                new FileType { FileTypeId = 4005, FileCategoryId = 40, FileExtension = ".dxf" },
                new FileType { FileTypeId = 4008, FileCategoryId = 40, FileExtension = ".fh" },
                new FileType { FileTypeId = 4009, FileCategoryId = 40, FileExtension = ".fh1" },
                new FileType { FileTypeId = 4010, FileCategoryId = 40, FileExtension = ".fh10" },
                new FileType { FileTypeId = 4011, FileCategoryId = 40, FileExtension = ".fh11" },
                new FileType { FileTypeId = 4012, FileCategoryId = 40, FileExtension = ".fh2" },
                new FileType { FileTypeId = 4013, FileCategoryId = 40, FileExtension = ".fh3" },
                new FileType { FileTypeId = 4014, FileCategoryId = 40, FileExtension = ".fh4" },
                new FileType { FileTypeId = 4015, FileCategoryId = 40, FileExtension = ".fh5" },
                new FileType { FileTypeId = 4016, FileCategoryId = 40, FileExtension = ".fh6" },
                new FileType { FileTypeId = 4017, FileCategoryId = 40, FileExtension = ".fh7" },
                new FileType { FileTypeId = 4018, FileCategoryId = 40, FileExtension = ".fh8" },
                new FileType { FileTypeId = 4019, FileCategoryId = 40, FileExtension = ".fh9" },
                new FileType { FileTypeId = 4020, FileCategoryId = 40, FileExtension = ".fodg" },
                new FileType { FileTypeId = 4022, FileCategoryId = 40, FileExtension = ".jfif" },
                new FileType { FileTypeId = 4023, FileCategoryId = 40, FileExtension = ".jif" },
                new FileType { FileTypeId = 4024, FileCategoryId = 40, FileExtension = ".jpe" },
                new FileType { FileTypeId = 4027, FileCategoryId = 40, FileExtension = ".met" },
                new FileType { FileTypeId = 4028, FileCategoryId = 40, FileExtension = ".mov" },
                new FileType { FileTypeId = 4029, FileCategoryId = 40, FileExtension = ".odg" },
                new FileType { FileTypeId = 4030, FileCategoryId = 40, FileExtension = ".otg" },
                new FileType { FileTypeId = 4031, FileCategoryId = 40, FileExtension = ".p65" },
                new FileType { FileTypeId = 4034, FileCategoryId = 40, FileExtension = ".pct" },
                new FileType { FileTypeId = 4038, FileCategoryId = 40, FileExtension = ".pm" },
                new FileType { FileTypeId = 4039, FileCategoryId = 40, FileExtension = ".pm6" },
                new FileType { FileTypeId = 4040, FileCategoryId = 40, FileExtension = ".pmd" },
                new FileType { FileTypeId = 4044, FileCategoryId = 40, FileExtension = ".pub" },
                new FileType { FileTypeId = 4045, FileCategoryId = 40, FileExtension = ".ras" },
                new FileType { FileTypeId = 4046, FileCategoryId = 40, FileExtension = ".sda" },
                new FileType { FileTypeId = 4047, FileCategoryId = 40, FileExtension = ".sgf" },
                new FileType { FileTypeId = 4048, FileCategoryId = 40, FileExtension = ".sgv" },
                new FileType { FileTypeId = 4049, FileCategoryId = 40, FileExtension = ".std" },
                new FileType { FileTypeId = 4051, FileCategoryId = 40, FileExtension = ".svgz" },
                new FileType { FileTypeId = 4052, FileCategoryId = 40, FileExtension = ".svm" },
                new FileType { FileTypeId = 4053, FileCategoryId = 40, FileExtension = ".sxd" },
                new FileType { FileTypeId = 4055, FileCategoryId = 40, FileExtension = ".tif" },
                new FileType { FileTypeId = 4057, FileCategoryId = 40, FileExtension = ".vdw" },
                new FileType { FileTypeId = 4058, FileCategoryId = 40, FileExtension = ".vdx" },
                new FileType { FileTypeId = 4059, FileCategoryId = 40, FileExtension = ".vsd" },
                new FileType { FileTypeId = 4060, FileCategoryId = 40, FileExtension = ".vsdm" },
                new FileType { FileTypeId = 4061, FileCategoryId = 40, FileExtension = ".vsdx" },
                new FileType { FileTypeId = 4062, FileCategoryId = 40, FileExtension = ".vss" },
                new FileType { FileTypeId = 4063, FileCategoryId = 40, FileExtension = ".vssm" },
                new FileType { FileTypeId = 4064, FileCategoryId = 40, FileExtension = ".vssx" },
                new FileType { FileTypeId = 4065, FileCategoryId = 40, FileExtension = ".vst" },
                new FileType { FileTypeId = 4066, FileCategoryId = 40, FileExtension = ".vstm" },
                new FileType { FileTypeId = 4067, FileCategoryId = 40, FileExtension = ".vstx" },
                new FileType { FileTypeId = 4068, FileCategoryId = 40, FileExtension = ".vsx" },
                new FileType { FileTypeId = 4069, FileCategoryId = 40, FileExtension = ".vtx" },
                new FileType { FileTypeId = 4075, FileCategoryId = 40, FileExtension = ".zmf" },
                new FileType { FileTypeId = 5001, FileCategoryId = 50, FileExtension = ".aai" },
                new FileType { FileTypeId = 5002, FileCategoryId = 50, FileExtension = ".art" },
                new FileType { FileTypeId = 5003, FileCategoryId = 50, FileExtension = ".arw" },
                new FileType { FileTypeId = 5004, FileCategoryId = 50, FileExtension = ".avi" },
                new FileType { FileTypeId = 5005, FileCategoryId = 50, FileExtension = ".avs" },
                new FileType { FileTypeId = 5006, FileCategoryId = 50, FileExtension = ".bmp" },
                new FileType { FileTypeId = 5007, FileCategoryId = 50, FileExtension = ".bmp2" },
                new FileType { FileTypeId = 5008, FileCategoryId = 50, FileExtension = ".bmp3" },
                new FileType { FileTypeId = 5009, FileCategoryId = 50, FileExtension = ".bpg" },
                new FileType { FileTypeId = 5010, FileCategoryId = 50, FileExtension = ".cals" },
                new FileType { FileTypeId = 5011, FileCategoryId = 50, FileExtension = ".cgm" },
                new FileType { FileTypeId = 5012, FileCategoryId = 50, FileExtension = ".cin" },
                new FileType { FileTypeId = 5013, FileCategoryId = 50, FileExtension = ".cmyk" },
                new FileType { FileTypeId = 5014, FileCategoryId = 50, FileExtension = ".cmyka" },
                new FileType { FileTypeId = 5015, FileCategoryId = 50, FileExtension = ".cr2" },
                new FileType { FileTypeId = 5016, FileCategoryId = 50, FileExtension = ".crw" },
                new FileType { FileTypeId = 5017, FileCategoryId = 50, FileExtension = ".cur" },
                new FileType { FileTypeId = 5018, FileCategoryId = 50, FileExtension = ".cut" },
                new FileType { FileTypeId = 5019, FileCategoryId = 50, FileExtension = ".dcm" },
                new FileType { FileTypeId = 5020, FileCategoryId = 50, FileExtension = ".dcr" },
                new FileType { FileTypeId = 5021, FileCategoryId = 50, FileExtension = ".dcx" },
                new FileType { FileTypeId = 5022, FileCategoryId = 50, FileExtension = ".dds" },
                new FileType { FileTypeId = 5023, FileCategoryId = 50, FileExtension = ".dib" },
                new FileType { FileTypeId = 5024, FileCategoryId = 50, FileExtension = ".djvu" },
                new FileType { FileTypeId = 5025, FileCategoryId = 50, FileExtension = ".dng" },
                new FileType { FileTypeId = 5027, FileCategoryId = 50, FileExtension = ".dpx" },
                new FileType { FileTypeId = 5028, FileCategoryId = 50, FileExtension = ".emf" },
                new FileType { FileTypeId = 5029, FileCategoryId = 50, FileExtension = ".epi" },
                new FileType { FileTypeId = 5030, FileCategoryId = 50, FileExtension = ".eps" },
                new FileType { FileTypeId = 5031, FileCategoryId = 50, FileExtension = ".eps2" },
                new FileType { FileTypeId = 5032, FileCategoryId = 50, FileExtension = ".eps3" },
                new FileType { FileTypeId = 5033, FileCategoryId = 50, FileExtension = ".epsf" },
                new FileType { FileTypeId = 5034, FileCategoryId = 50, FileExtension = ".epsi" },
                new FileType { FileTypeId = 5035, FileCategoryId = 50, FileExtension = ".ept" },
                new FileType { FileTypeId = 5036, FileCategoryId = 50, FileExtension = ".exr" },
                new FileType { FileTypeId = 5037, FileCategoryId = 50, FileExtension = ".fax" },
                new FileType { FileTypeId = 5038, FileCategoryId = 50, FileExtension = ".fig" },
                new FileType { FileTypeId = 5039, FileCategoryId = 50, FileExtension = ".fits" },
                new FileType { FileTypeId = 5040, FileCategoryId = 50, FileExtension = ".fpx" },
                new FileType { FileTypeId = 5041, FileCategoryId = 50, FileExtension = ".gif" },
                new FileType { FileTypeId = 5042, FileCategoryId = 50, FileExtension = ".gplt" },
                new FileType { FileTypeId = 5043, FileCategoryId = 50, FileExtension = ".gray" },
                new FileType { FileTypeId = 5044, FileCategoryId = 50, FileExtension = ".hdr" },
                new FileType { FileTypeId = 5045, FileCategoryId = 50, FileExtension = ".hpgl" },
                new FileType { FileTypeId = 5046, FileCategoryId = 50, FileExtension = ".hrz" },
                new FileType { FileTypeId = 5047, FileCategoryId = 50, FileExtension = ".ico" },
                new FileType { FileTypeId = 5048, FileCategoryId = 50, FileExtension = ".j2c" },
                new FileType { FileTypeId = 5049, FileCategoryId = 50, FileExtension = ".j2k" },
                new FileType { FileTypeId = 5050, FileCategoryId = 50, FileExtension = ".jbig" },
                new FileType { FileTypeId = 5051, FileCategoryId = 50, FileExtension = ".jng" },
                new FileType { FileTypeId = 5052, FileCategoryId = 50, FileExtension = ".jp2" },
                new FileType { FileTypeId = 5053, FileCategoryId = 50, FileExtension = ".jpeg" },
                new FileType { FileTypeId = 5054, FileCategoryId = 50, FileExtension = ".jpg" },
                new FileType { FileTypeId = 5055, FileCategoryId = 50, FileExtension = ".jpt" },
                new FileType { FileTypeId = 5056, FileCategoryId = 50, FileExtension = ".jxr" },
                new FileType { FileTypeId = 5057, FileCategoryId = 50, FileExtension = ".m2v" },
                new FileType { FileTypeId = 5058, FileCategoryId = 50, FileExtension = ".man" },
                new FileType { FileTypeId = 5059, FileCategoryId = 50, FileExtension = ".mat" },
                new FileType { FileTypeId = 5060, FileCategoryId = 50, FileExtension = ".miff" },
                new FileType { FileTypeId = 5061, FileCategoryId = 50, FileExtension = ".mng" },
                new FileType { FileTypeId = 5062, FileCategoryId = 50, FileExtension = ".mono" },
                new FileType { FileTypeId = 5063, FileCategoryId = 50, FileExtension = ".mpc" },
                new FileType { FileTypeId = 5064, FileCategoryId = 50, FileExtension = ".mpeg" },
                new FileType { FileTypeId = 5065, FileCategoryId = 50, FileExtension = ".mpr" },
                new FileType { FileTypeId = 5066, FileCategoryId = 50, FileExtension = ".mrsid" },
                new FileType { FileTypeId = 5067, FileCategoryId = 50, FileExtension = ".mrw" },
                new FileType { FileTypeId = 5068, FileCategoryId = 50, FileExtension = ".msl" },
                new FileType { FileTypeId = 5069, FileCategoryId = 50, FileExtension = ".mtv" },
                new FileType { FileTypeId = 5070, FileCategoryId = 50, FileExtension = ".mvg" },
                new FileType { FileTypeId = 5071, FileCategoryId = 50, FileExtension = ".nef" },
                new FileType { FileTypeId = 5072, FileCategoryId = 50, FileExtension = ".orf" },
                new FileType { FileTypeId = 5073, FileCategoryId = 50, FileExtension = ".otb" },
                new FileType { FileTypeId = 5074, FileCategoryId = 50, FileExtension = ".p7" },
                new FileType { FileTypeId = 5075, FileCategoryId = 50, FileExtension = ".palm" },
                new FileType { FileTypeId = 5076, FileCategoryId = 50, FileExtension = ".pam" },
                new FileType { FileTypeId = 5077, FileCategoryId = 50, FileExtension = ".pbm" },
                new FileType { FileTypeId = 5078, FileCategoryId = 50, FileExtension = ".pcd" },
                new FileType { FileTypeId = 5079, FileCategoryId = 50, FileExtension = ".pcds" },
                new FileType { FileTypeId = 5080, FileCategoryId = 50, FileExtension = ".pcl" },
                new FileType { FileTypeId = 5081, FileCategoryId = 50, FileExtension = ".pcx" },
                new FileType { FileTypeId = 5083, FileCategoryId = 50, FileExtension = ".pef" },
                new FileType { FileTypeId = 5084, FileCategoryId = 50, FileExtension = ".pfa" },
                new FileType { FileTypeId = 5085, FileCategoryId = 50, FileExtension = ".pfb" },
                new FileType { FileTypeId = 5086, FileCategoryId = 50, FileExtension = ".pfm" },
                new FileType { FileTypeId = 5087, FileCategoryId = 50, FileExtension = ".pgm" },
                new FileType { FileTypeId = 5088, FileCategoryId = 50, FileExtension = ".picon" },
                new FileType { FileTypeId = 5089, FileCategoryId = 50, FileExtension = ".pict" },
                new FileType { FileTypeId = 5090, FileCategoryId = 50, FileExtension = ".pix" },
                new FileType { FileTypeId = 5091, FileCategoryId = 50, FileExtension = ".png" },
                new FileType { FileTypeId = 5092, FileCategoryId = 50, FileExtension = ".png00" },
                new FileType { FileTypeId = 5093, FileCategoryId = 50, FileExtension = ".png24" },
                new FileType { FileTypeId = 5094, FileCategoryId = 50, FileExtension = ".png32" },
                new FileType { FileTypeId = 5095, FileCategoryId = 50, FileExtension = ".png48" },
                new FileType { FileTypeId = 5096, FileCategoryId = 50, FileExtension = ".png64" },
                new FileType { FileTypeId = 5097, FileCategoryId = 50, FileExtension = ".png8" },
                new FileType { FileTypeId = 5098, FileCategoryId = 50, FileExtension = ".pnm" },
                new FileType { FileTypeId = 5099, FileCategoryId = 50, FileExtension = ".ppm" },
                new FileType { FileTypeId = 5100, FileCategoryId = 50, FileExtension = ".ps" },
                new FileType { FileTypeId = 5101, FileCategoryId = 50, FileExtension = ".ps2" },
                new FileType { FileTypeId = 5102, FileCategoryId = 50, FileExtension = ".ps3" },
                new FileType { FileTypeId = 5103, FileCategoryId = 50, FileExtension = ".psb" },
                new FileType { FileTypeId = 5104, FileCategoryId = 50, FileExtension = ".psd" },
                new FileType { FileTypeId = 5105, FileCategoryId = 50, FileExtension = ".ptif" },
                new FileType { FileTypeId = 5106, FileCategoryId = 50, FileExtension = ".pwp" },
                new FileType { FileTypeId = 5107, FileCategoryId = 50, FileExtension = ".rad" },
                new FileType { FileTypeId = 5108, FileCategoryId = 50, FileExtension = ".raf" },
                new FileType { FileTypeId = 5109, FileCategoryId = 50, FileExtension = ".rfg" },
                new FileType { FileTypeId = 5110, FileCategoryId = 50, FileExtension = ".rgb" },
                new FileType { FileTypeId = 5111, FileCategoryId = 50, FileExtension = ".rgba" },
                new FileType { FileTypeId = 5112, FileCategoryId = 50, FileExtension = ".rla" },
                new FileType { FileTypeId = 5113, FileCategoryId = 50, FileExtension = ".rle" },
                new FileType { FileTypeId = 5114, FileCategoryId = 50, FileExtension = ".sct" },
                new FileType { FileTypeId = 5115, FileCategoryId = 50, FileExtension = ".sfw" },
                new FileType { FileTypeId = 5116, FileCategoryId = 50, FileExtension = ".sgi" },
                new FileType { FileTypeId = 5117, FileCategoryId = 50, FileExtension = ".sid" },
                new FileType { FileTypeId = 5118, FileCategoryId = 50, FileExtension = ".sun" },
                new FileType { FileTypeId = 5119, FileCategoryId = 50, FileExtension = ".svg" },
                new FileType { FileTypeId = 5120, FileCategoryId = 50, FileExtension = ".tga" },
                new FileType { FileTypeId = 5121, FileCategoryId = 50, FileExtension = ".tiff" },
                new FileType { FileTypeId = 5122, FileCategoryId = 50, FileExtension = ".tim" },
                new FileType { FileTypeId = 5123, FileCategoryId = 50, FileExtension = ".ttf" },
                new FileType { FileTypeId = 5124, FileCategoryId = 50, FileExtension = ".uil" },
                new FileType { FileTypeId = 5125, FileCategoryId = 50, FileExtension = ".uyvy" },
                new FileType { FileTypeId = 5126, FileCategoryId = 50, FileExtension = ".vicar" },
                new FileType { FileTypeId = 5127, FileCategoryId = 50, FileExtension = ".viff" },
                new FileType { FileTypeId = 5128, FileCategoryId = 50, FileExtension = ".wbmp" },
                new FileType { FileTypeId = 5129, FileCategoryId = 50, FileExtension = ".wdp" },
                new FileType { FileTypeId = 5130, FileCategoryId = 50, FileExtension = ".webp" },
                new FileType { FileTypeId = 5131, FileCategoryId = 50, FileExtension = ".wmf" },
                new FileType { FileTypeId = 5132, FileCategoryId = 50, FileExtension = ".wpg" },
                new FileType { FileTypeId = 5133, FileCategoryId = 50, FileExtension = ".x" },
                new FileType { FileTypeId = 5134, FileCategoryId = 50, FileExtension = ".x3f" },
                new FileType { FileTypeId = 5135, FileCategoryId = 50, FileExtension = ".xbm" },
                new FileType { FileTypeId = 5136, FileCategoryId = 50, FileExtension = ".xcf" },
                new FileType { FileTypeId = 5137, FileCategoryId = 50, FileExtension = ".xpm" },
                new FileType { FileTypeId = 5138, FileCategoryId = 50, FileExtension = ".xwd" },
                new FileType { FileTypeId = 5139, FileCategoryId = 50, FileExtension = ".ycbcr" },
                new FileType { FileTypeId = 5140, FileCategoryId = 50, FileExtension = ".ycbcra" },
                new FileType { FileTypeId = 5141, FileCategoryId = 50, FileExtension = ".yuv" }
            );
        }

        public void SeedConvertResultTypes()
        {
            if (!this.ConvertResultTypes.Any())
            {
                this.ConvertResultTypes.AddRange(
                    new ConvertResultType { ConvertResultTypeId = 0, ConvertResultTypeCode = "Completed" },
                    new ConvertResultType { ConvertResultTypeId = 10, ConvertResultTypeCode = "FileBytesEmpty" },
                    new ConvertResultType { ConvertResultTypeId = 20, ConvertResultTypeCode = "FileExtensionEmpty" },
                    new ConvertResultType { ConvertResultTypeId = 30, ConvertResultTypeCode = "InvalidFileExtension" },
                    new ConvertResultType { ConvertResultTypeId = 40, ConvertResultTypeCode = "FormatNotSupported" },
                    new ConvertResultType { ConvertResultTypeId = 99, ConvertResultTypeCode = "UnknownError" }
                    );
            }
        }

        public void SeedTestData()
        {

        }
    }
}
