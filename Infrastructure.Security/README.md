About

The package is designed to provide robust cryptographic services for .NET applications, enabling secure key generation and data protection.

How to Use

    var text = "Hello World!!!";
    var message = string.Empty;
    var secureKey32BitSize = 32;
    var secureKey64BitSize = 64;

    var secureKey32Bit = CryptographyService.GenerateSecureKey(secureKey32BitSize);
    var secureKey64Bit = CryptographyService.GenerateSecureKey(secureKey64BitSize);
    var secureKey64BitLength = Convert.ToBase64String(new byte[secureKey64BitSize]).Length;

    if (!string.IsNullOrWhiteSpace(secureKey64Bit) &&
        secureKey64Bit.Length == secureKey64BitLength)
    {
        message = "The generate secure key was successful!";
    }
    else
    {
        message = "The generate secure key was unsuccessful!";
    }

    Console.WriteLine(message);

    var encryptText = CryptographyService.Encrypt(text, secureKey32Bit);
    var decryptText = CryptographyService.Decrypt(encryptText, secureKey32Bit);

    if (!string.IsNullOrWhiteSpace(encryptText) &&
        text == decryptText)
    {
        message = "The encrypt and decrypt was successful!";
    }
    else
    {
        message = "The encrypt and decrypt was unsuccessful!";
    }
    
    Console.WriteLine(message);
    
 
Main Types

The main types provided by this library are:

    Infrastructure.Security.Services.CryptographyService


Feedback & Contributing

Infrastructure.Security is released as open source under the MIT license. Bug reports and contributions are welcome at the GitHub repository.
