using System;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;

namespace SriHash
{
    [Command(
        Description = "Generates the SRI hash to use with the 'integrity' attribute on a <script> tag in HTML"
    )]
    class Program
    {
        public static Task<int> Main(string[] args) => CommandLineApplication.ExecuteAsync<Program>(args);

        [Argument(0, Description = "The URI of the resource")]
        [Required]
        public string Uri { get; }

        [Option("--html", Description = "Generate the output as HTML.")]
        public bool Html { get; }

        private async Task OnExecute()
        {
            byte[] hash;
            using (var client = new HttpClient())
            using (var request = await client.GetStreamAsync(Uri))
            using (var algorithm = SHA384.Create())
            {
                hash = algorithm.ComputeHash(request);
            }

            var integrity = "sha384-" + Convert.ToBase64String(hash);
            if (Html)
            {
                Console.WriteLine($"<script src=\"{Uri}\" integrity=\"{integrity}\" crossorigin=\"anonymous\"></script>");
            }
            else
            {
                Console.Write(integrity);
            }
        }
    }
}
