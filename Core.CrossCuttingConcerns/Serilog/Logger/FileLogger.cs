﻿using Core.CrossCuttingConcerns.Serilog.ConfigurationModels;
using Core.CrossCuttingConcerns.Serilog.Messages;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.CrossCuttingConcerns.Serilog.Logger;

public class FileLogger:LoggerServiceBase
{
    private readonly IConfiguration _configuration;

    public FileLogger(IConfiguration configuration)
    {
        _configuration = configuration;

        FileLogConfiguration logConfig = 
            configuration.GetSection("SerilogConfigurations:FileLogConfiguration")
            .Get<FileLogConfiguration>() ?? throw new Exception(SerilogMessages.NullOptionsMessage);

        string logFilePath = string.Format(format: "{0}{1}", arg0: Directory.GetCurrentDirectory() + logConfig.FolderPath, arg1: ".txt");

        Logger = new LoggerConfiguration().WriteTo.File(
            logFilePath, rollingInterval: RollingInterval.Day,//Her gün yeni bir dosya oluştur anlamında 
            retainedFileCountLimit: null,                    //Eski dosyaları silme limiti
            fileSizeLimitBytes: 5000000,                    //Dosya limit boyutu
            outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}{Exception}"
            ).CreateLogger();
    }
}
