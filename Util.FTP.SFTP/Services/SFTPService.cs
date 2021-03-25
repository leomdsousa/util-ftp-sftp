using Util.FTP.SFTP.Services.Interfaces;
using SshNet;
using Renci.SshNet;
using System.Threading.Tasks;
using System.Collections.Generic;
using Renci.SshNet.Sftp;
using System;
using System.IO;
using System.Linq;

namespace Util.FTP.SFTP.Services
{
    public class SFTPService : ISFTPService
    {
        private readonly ISftpClient _sftpClient;
        public SFTPService(
                string host,
                int port,
                string username,
                string password
            )
        {
            _sftpClient = CriaCliente(host, port, username, password);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="host"></param>
        /// <param name="port"></param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public SftpClient CriaCliente(string host, int port, string username, string password)
        {
            try
            {
                return new SftpClient(host, port, username, password);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caminho"></param>
        /// <param name="destino"></param>
        /// <returns></returns>
        public async Task Download(string caminho, string destino)
        {
            try
            {
                using(var stream = new FileStream(caminho, FileMode.Open))
                {
                    await Task.Run(() => _sftpClient.DownloadFile(destino, stream));
                }

                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caminho"></param>
        /// <param name="destino"></param>
        /// <returns></returns>
        public async Task Move(string caminho, string destino)
        {
            try
            { 
                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<SftpFile>> RetornaArquivos(string caminho)
        {
            try
            {
                var files = new List<SftpFile>();

                files = await Task.Run(() => _sftpClient.ListDirectory(caminho).ToList());

                return files;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="caminho"></param>
        /// <param name="destino"></param>
        /// <returns></returns>
        public async Task Upload(string caminho, string destino)
        {
            try
            {
                using (var stream = new FileStream(caminho, FileMode.Open))
                {
                    await Task.Run(() => _sftpClient.UploadFile(stream, destino));
                }

                return;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
