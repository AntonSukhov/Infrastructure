About

The package is designed to provide robust cryptographic services for .NET applications, enabling secure key generation and data protection.

How to Use

    var keySize = 64;
    var message = string.Empty;

    var secureKey = CryptographyService.GenerateSecureKey(keySize);
    var secureKeyLength = Convert.ToBase64String(new byte[keySize]).Length;

    if (!string.IsNullOrWhiteSpace(secureKey) &&
        secureKey.Length == secureKeyLength)
    {
        message = "The generate secure key was successful!";
    }
    else
    {
        message = "The generate secure key was unsuccessful!";
    }

    Console.WriteLine(message);
    
 
Main Types

The main types provided by this library are:

    Infrastructure.Security.Services.CryptographyService


Feedback & Contributing

Infrastructure.Security is released as open source under the MIT license. Bug reports and contributions are welcome at the GitHub repository.
