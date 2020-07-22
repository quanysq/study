﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GeneratorLogAnalyze.Common
{
  class CertUtil
  {
    public static string ExportToPEM(X509Certificate cert)
    {
      StringBuilder builder = new StringBuilder();
      builder.AppendLine("-----BEGIN CERTIFICATE-----");
      builder.AppendLine(Convert.ToBase64String(cert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks));
      builder.AppendLine("-----END CERTIFICATE-----");
      return builder.ToString();
    }

    public static void VerifyCert(X509Certificate2 certificate2, StringBuilder sb, Action action)
    {
      sb.AppendLine(string.Format("Subject: [{0}]", certificate2.Subject));
      sb.AppendLine(string.Format("Issuer: [{0}]", certificate2.Issuer));
      sb.AppendLine(string.Format("Thumbprint: [{0}]", certificate2.Thumbprint));
      sb.AppendLine(string.Format("Expiry Date: [{0}]", certificate2.NotAfter));
      sb.AppendLine(string.Format("Signature Algorithm: [{0}]", certificate2.SignatureAlgorithm.FriendlyName));
      if (action != null) action();
      bool isVerified = certificate2.Verify();
      sb.AppendLine(string.Format("Initial certificate validation passed? [{0}]", isVerified));
      bool isSelfSigned = certificate2.Issuer == certificate2.Subject;
      sb.AppendLine(string.Format("Is self signed certificate? [{0}]", isSelfSigned));
      if (isSelfSigned && isVerified) return;

      try
      {
        X509Chain chain = new X509Chain();
        chain.ChainPolicy.VerificationFlags = X509VerificationFlags.NoFlag;
        chain.ChainPolicy.RevocationMode = X509RevocationMode.NoCheck;
        isVerified = chain.Build(certificate2);
        sb.AppendLine(string.Format("Build LDAP/AD server certificate chain with no flags? [{0}]", isVerified));
        if (chain.ChainElements.Count == 1)
        {
          sb.AppendLine("No found LDAP/AD server certificate chain.");
        }
        else
        {
          for (int i = 0; i < chain.ChainElements.Count; i++)
          {
            X509Certificate2 chain_cert = chain.ChainElements[i].Certificate;
            sb.AppendLine(string.Format("Certificate ID in chain: [{0}/{1}]", i + 1, chain.ChainElements.Count));
            sb.AppendLine(string.Format("Subject: [{0}]", chain_cert.Subject));
            sb.AppendLine(string.Format("Issuer: [{0}]", chain_cert.Issuer));
            sb.AppendLine(string.Format("Thumbprint: [{0}]", chain_cert.Thumbprint));
            sb.AppendLine(string.Format("Expiry Date: [{0}]", chain_cert.NotAfter));
            sb.AppendLine(string.Format("Signature Algorithm: [{0}]", chain_cert.SignatureAlgorithm.FriendlyName));
          }
        }
      }
      catch (Exception ex)
      {
        sb.AppendLine("Error found in validating certificate: ");
        sb.AppendLine(string.Format("[{0}]", ex));
      }
    }
  }
}
