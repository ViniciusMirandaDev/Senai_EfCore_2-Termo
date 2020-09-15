using Microsoft.AspNetCore.Http;
using System;
using System.IO;

namespace EntityFCore.Utils
{
    public static class Upload
    {
        public static string Local(IFormFile file)
        {
            //Gera um nome do arquivo com guid
            //Pega a extensão do arquivo enviado e concatena
            //Exemplo: NomeArquivo 3843748374bhsbdsdjdshj. png
            var nomeArquivo = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);

            //Pega o diretório da aplicação corrente
            //Concatena com a pasta que irá salvar o arquivo
            //Concatena com o nome do arquivo
            //c://users//User1//aplicacao//upload///imagens//eji3849348fnseo.png
            var caminhoArquivo = Path.Combine(Directory.GetCurrentDirectory(), @"wwwRoot\upload\imagens", nomeArquivo);

            //gera um objeto FileStream que irá armazenas a minha imagem
            using var streamImagem = new FileStream(caminhoArquivo, FileMode.Create);

            //Copia a imagem para o local informado
            file.CopyTo(streamImagem);

            return "http://localhost:56407/upload/imagens/" + nomeArquivo;
        }
    }
}
