using Magicodes.ExporterAndImporter.Core.Models;
using Magicodes.ExporterAndImporter.Core;
using Magicodes.ExporterAndImporter.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRHelper.Utils
{
    public static class ExcelUtil
    {
        /// <summary>
        /// 通用导入 excel 文件
        /// </summary>
        /// <param name="filePath">Excel 文件路径</param>
        public static async Task<ImportResult<T>> ImportExcel<T>(string filePath) where T : class, new()
        {
            IImporter importer = new ExcelImporter();
            var result = await importer.Import<T>(filePath);
            return result;
        }

        /// <summary>
        /// 根据模板导出到excel
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="templateModel"></param>
        /// <param name="savePath"></param>
        /// <param name="fileName"></param>
        /// <param name="templatePath"></param>
        /// <returns></returns>
        public static async Task<string> ExportExcelByTemplate<T>(T templateModel, string filePath, string templatePath) where T : class, new()
        {
            IExportFileByTemplate exporter = new ExcelExporter();
            if (File.Exists(filePath)) File.Delete(filePath);
            await exporter.ExportByTemplate(filePath, templateModel, templatePath);
            return filePath;
        }
    }
}
