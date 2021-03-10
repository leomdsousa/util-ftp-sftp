using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using FluentFTP;

namespace Util.FTP.SFTP.Services.Interfaces
{
    public interface IFTPService
    {
        FtpClient CriaCliente(string host, NetworkCredential credenciais);
        Task<List<string>> RetornaArquivos(string caminho);
        Task Download(string arquivo, string destino);
        Task Upload(string arquivo, string destino);
        Task Mover(string arquivo, string destino);
    }
}
