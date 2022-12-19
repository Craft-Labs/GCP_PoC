### Steps
1. Create service account in your project with Service Accounts Admin permission
2. Create JSON key for that service account
3. Put it in your secret files like the example below

```
{
  "SACredentials": {
    "type": "service_account",
    "project_id": "cobalt-aria-354302",
    "private_key_id": "992eaae86ce9cb2FAKE99cad99e8ae2c6420",
    "private_key": "-----BEGIN PRIVATE KEY-----\nMIIEvwIFAKE_SECRET_BROHATx4aLEDQ==\n-----END PRIVATE KEY-----\n",
    "client_email": "gcp-528@cobalt-aria-354302.iam.gserviceaccount.com",
    "client_id": "10814FAKE23714581",
    "auth_uri": "https://accounts.google.com/o/oauth2/auth",
    "token_uri": "https://oauth2.googleapis.com/token",
    "auth_provider_x509_cert_url": "https://www.googleapis.com/oauth2/v1/certs",
    "client_x509_cert_url": "https://www.googleapis.com/robot/v1/metadata/x509/gcp-528%40cobalt-aria-354302.iam.gserviceaccount.com"
  }
}
```