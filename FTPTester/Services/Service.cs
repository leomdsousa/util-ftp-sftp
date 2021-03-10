using FluentFTP;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace FTPTester.Services
{
    public class Service
    {
        FtpClient _client;

        public Service()
        {
            _client = CriaFTPClient();
        }

        public FtpClient CriaFTPClient()
        {
            return new FtpClient("localhost", new System.Net.NetworkCredential { UserName = "usuario", Password = "usuario" });
        }

        public async Task<List<string>> RetornaArquivos(string caminho)
        {
            List<string> listaArquivos = new List<string>();

            using (_client)
            {
                FtpListItem[] listagem = await _client.GetListingAsync();

                foreach (var item in listagem)
                {
                    if (item.Type == FtpFileSystemObjectType.File)
                    {
                        listaArquivos.Add(item.FullName);
                    }
                }
            }

            return listaArquivos;
        }

        public async void Download(string nome)
        {       
                //1 Parametro - caminho local onde será baixado
                //2 Parametro - caminho no local (contar a partir da raiz do servidor)
                await _client.DownloadFileAsync(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "teste2.pdf")
                                              , Path.Combine("Uploads", nome));
        }

        public async void Move(string arquivo)
        {
            //1 Parametro -caminho do arquivo a ser movido  
            //2 Parametro - caminho do destino no servidor (contar a partir da raiz do servidor)
            await _client.MoveFileAsync(Path.Combine("Uploads", arquivo)
                                      , Path.Combine("Moveds", "movido.pdf"), FtpRemoteExists.Overwrite);
        }

        public async void Upload(string caminho)
        {
            //1 Parametro -caminho do arquivo a ser subido  
            //2 Parametro - caminho do destino no servidor (contar a partir da raiz do servidor)
            await _client.UploadFileAsync(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) , caminho)
                                        , Path.Combine("Uploads", caminho), FtpRemoteExists.Overwrite);
        }
    }
}
