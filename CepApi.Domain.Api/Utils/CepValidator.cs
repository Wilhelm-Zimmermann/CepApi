namespace CepApi.Domain.Api.Utils;
using System.Text.RegularExpressions;

public static class CepValidator
{
    public static bool IsValidCep(string cep)
    {
        // Define the regular expression for valid CEP formats
        var cepRegex = new Regex(@"^\d{8}$|^\d{5}-\d{3}$");

        return cepRegex.IsMatch(cep);
    }
}