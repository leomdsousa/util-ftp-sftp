using FluentFTP;
using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Util.FTP.SFTP.Services.Interfaces;

namespace Util.FTP.SFTP.Services
{
    public class FTPService : IFTPService
    {
        private readonly IFtpClient _cliente;

        public FTPService(string host, NetworkCredential credenciais)
        {
            _cliente = CriaCliente(host, credenciais);
        }

        /// <summary>
        /// Cria cliente FTP
        /// </summary>
        /// <param name="host">Nome do servidor FTP</param>
        /// <param name="credenciais">Objeto contendo as credenciais para o acesso ao servidor FTP</param>
        /// <returns> objeto do tipo FtpClient </returns>
        public FtpClient CriaCliente(string host, NetworkCredential credenciais)
        {
            try
            {
                return new FtpClient(host,
            new NetworkCredential
            {
                UserName = credenciais.UserName,
                Password = credenciais.Password
            });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Executa download de arquivo no caminho remoto para o local específicado
        /// </summary>
        /// <param name="arquivo">Caminho local onde será baixado</param>
        /// <param name="destino">Caminho no local (contar a partir da raiz do servidor</param>
        /// <returns></returns>
        public async Task Download(string arquivo, string destino)
        {
            try
            {
                await _cliente.DownloadFileAsync(arquivo, destino, FtpLocalExists.Overwrite);
            }
            catch (Exception ex)
            {
                throw ex; 
            }
        }

        public async Task Mover(string arquivo, string destino)
        {
            try
            {
                await _cliente.MoveFileAsync(arquivo, destino, FtpRemoteExists.Overwrite);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Leitura e retorno dos arquivos contidos no caminho remoto específicado do servidor FTP
        /// </summary>
        /// <param name="caminho">Caminho no servidor FTP para a leitura</param>
        /// <returns> Lista com os nomes dos arquivos </returns>
        public async Task<List<string>> RetornaArquivos(string caminho)
        {
            try
            {
                List<string> arquivos = new List<string>();

                FtpListItem[] listagem = await _cliente.GetListingAsync();

                foreach (var item in listagem)
                {
                    if (item.Type == FtpFileSystemObjectType.File)
                    {
                        arquivos.Add(item.FullName);
                    }
                }

                return arquivos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Executa upload de arquivo no caminho local para o servidor no caminho específicado
        /// </summary>
        /// <param name="arquivo">Caminho do arquivo no diretório local</param>
        /// <param name="destino">Destino do arquivo no diretório remoto</param>
        /// <returns></returns>
        public async Task Upload(string arquivo, string destino)
        {
            try
            {
                await _cliente.UploadFileAsync(arquivo, destino, FtpRemoteExists.Overwrite);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
