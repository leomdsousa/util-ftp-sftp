using System.Collections.Generic;
using System.Threading.Tasks;
using Renci.SshNet;
using Renci.SshNet.Sftp;

namespace Util.FTP.SFTP.Services.Interfaces
{
    public interface ISFTPService
    {
        SftpClient CriaCliente(string host, string username, string password);
        Task<List<SftpFile>> RetornaArquivos(string caminho);
        Task Download(string caminho, string destino);
        Task Upload(string caminho, string destino);
        Task Move(string caminho, string destino);
    }
}
