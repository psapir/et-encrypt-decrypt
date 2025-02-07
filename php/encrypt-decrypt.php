<?php

class Crypto {
    private $encryptionKey;
    private $iv;

    public function __construct($password, $saltHex, $ivHex)
    {
        // Convert salt & IV from hexadecimal to binary
        $salt = hex2bin($saltHex);
        $this->iv = hex2bin($ivHex);

        // Ensure salt and IV sizes are correct
        if (strlen($salt) !== 8) {
            throw new Exception("Salt must be exactly 8 bytes (16 hex characters).");
        }
        if (strlen($this->iv) !== 16) {
            throw new Exception("IV must be exactly 16 bytes (32 hex characters).");
        }

        // Derive a 32-byte key using PBKDF2 (SHA-1)
        $this->encryptionKey = hash_pbkdf2("sha1", $password, $salt, 1000, 32, true);
    }

    public function encrypt($data)
    {
        // Encrypt the data
        $encrypted = openssl_encrypt($data, 'AES-256-CBC', $this->encryptionKey, OPENSSL_RAW_DATA, $this->iv);
        
        // Return Base64-encoded ciphertext
        return base64_encode($encrypted);
    }
}

// Provide Password, Salt & IV as Hexadecimal Strings
$password = "secure_pwd"; // User-defined password
$saltHex = "a1b2c3d4e5f60711"; // 8-byte Salt (16 hex chars)
$ivHex = "11223344556677889900aavvccddeeff"; // 16-byte IV (32 hex chars)

// Create an instance with predefined values
$crypto = new Crypto($password, $saltHex, $ivHex);

// Encrypt email
$email = "pato@example.com";
$encryptedEmail = $crypto->encrypt($email);
echo "Email: " . $email . PHP_EOL;
echo "Encrypted Email (Use in SFMC to decrypt value): " . $encryptedEmail . PHP_EOL;

?>
