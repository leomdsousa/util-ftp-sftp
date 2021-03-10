using Util.FTP.SFTP.Services.Interfaces;
using SshNet;
using Renci.SshNet;
using System.Threading.Tasks;
using System.Collections.Generic;
using Renci.SshNet.Sftp;

namespace Util.FTP.SFTP.Services
{
    public class SFTPService : ISFTPService
    {
        public SFTPService()
        {
            
        }

        public SftpClient CriaCliente(string host, string username, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task Download(string caminho, string destino)
        {
            throw new System.NotImplementedException();
        }

        public Task Move(string caminho, string destino)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<SftpFile>> RetornaArquivos(string caminho)
        {
            throw new System.NotImplementedException();
        }

        public Task Upload(string caminho, string destino)
        {
            throw new System.NotImplementedException();
        }
    }
}
