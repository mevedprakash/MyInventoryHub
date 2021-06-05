using System;
using System.Collections.Generic;
using System.Text;

namespace Interface
{
    public interface IJwtService
    {
        string CreateToken(Dictionary<string, string> keyValuePairs, DateTime tokenValidity);
        Dictionary<string, string> GetTokenClaims(string token, List<string> claims = null);
    }
}
