using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace civilreg1
{
    class RSA_ALGO
    {
        UnicodeEncoding ByteConverter = new UnicodeEncoding();
        RSACryptoServiceProvider RSA = new RSACryptoServiceProvider();


        #region Encryption
    
        
        public string Encryption(string strText)
        {
            var publicKey = "<RSAKeyValue><Modulus>21wEnTU+mcD2w0Lfo1Gv4rtcSWsQJQTNa6gio05AOkV/Er9w3Y13Ddo5wGtjJ19402S71HUeN0vbKILLJdRSES5MHSdJPSVrOqdrll/vLXxDxWs/U0UT1c8u6k/Ogx9hTtZxYwoeYqdhDblof3E75d9n2F0Zvf6iTb4cI7j6fMs=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            //publicKey = "<RSAKeyValue><Modulus>zhJtmTVrl/NBmQhJVGKtet9RFWZ4OHoLqblERGbVDLQyVS7r/1UCMwMSD5Gis/Uf0AJG/TE32S/2RCHs7KnKfCyDrTEksy9lRorkOlNf/c1DmqyceflrR3vOTDTTTu6k+rU3aslHKbs6VFaFg4x+Z1ogFu0/ZJD4esaTXwxn4FO0NWgsCsCMJTA6niURIpc2bxhRNKDivYdiaKXiCbjcAUzKShiQSkdB1wfZ0w4VH6456gPekQLS0Q8xP4t23M9fPQxgnVLtWfaeu92CzZ3I19dyZBuFcTFFmWbK2J5P+Lzipq6+ZhSHShWlk1ctihhW7ELxYtI3aLdMsZebW+EySijqT9UlJmY8aha3YsZmDq6T18Ih1k1CEW2/bWtxll/9BrpzORe2ja29EP1vRADjF7r7l6M9SwOAy9iuiz5CYYDcbrOS3e8j76KaNSxjzU+gh/KCFpuv8jrBGplAz9ync7PRQiaoiexLRyj3wCHWVNCkACvlAu5oGv/ZRdY7XRfTKM+6bKL01iGpkxYTLCScY77ADeimrdV89MaMES5J8u0l5/h9Da/S/eDqTJdl00NQSkhlpJKRs9I5js+1DzUwEr58J2ZWu9D7Xou0gYh2Bv+ojW/bbMBjQCWczByoGj7S7sR3ytFdgN0sYaCb7pGJO2+K5cVivaG4zX1Jcylaktk=</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";
            publicKey = @"<RSAKeyValue>
<Modulus>y2N/sDIZJXWGOEirIe+fQ30xI0hFWLzwfs6dwQa9hq/sBqnAXpaAl4oYgMX0RNxqHpSmFc4CiZaFfPhkW7XMIGfWaljCKnTTgTSo2gGW7F8CVjWhaETG0EZmBKp9vrY/Xb3rkn6MBO7VexpCIVdUJ1WBtIaIi1katjDw3CV+UGE2wElaAX2AzZQonRzwckjYRQLQWaz/MRL0po7KHc7hQ3ivcvx+JPeEgZko2AXAURQK6MPFj4HUSpZbLXTgUvEadiv7noCNTvZqcb7PZ6TEaCQme9K2B7RUBvc/DeIW7Qy+cvilEJWT3IPd0I0DG/cDzctftIE2DrJh7CBVeiVZq1mc8PMWVyf8lTq2JfW6g5usA0zm72+r7VwyPq5ShOxlV/UUJapRFVZ4SyUwnTkjIUskdNnb1TpFsFXFEFXwi9b4KSy3kmox7hFjEL6p0rE8w/JaTQeVCns++yCOivyAM/QmztfFhjAVBQUfPF4K0Euc7xRf1sS0V4SNo2SjHUDcfLOtoqFLHJSj1hPxdEAqHkBKYnOPaUHb3q/sQX3eGyR+P65REjy2rso4VX3e5Pwle9IWVos5wxvNouNnN3rJlb+fpjnZc6/DpofkjXAcm/6xtXNNJDsfUCGI6cYRIpd6dn/WkT2kQHUVYF1x5NqbCIJyEpVKU84NRb9EjiKCiO0=</Modulus>
<Exponent>AQAB</Exponent>
</RSAKeyValue>";
            var testData = Encoding.UTF8.GetBytes(strText);
            using (var rsa = new RSACryptoServiceProvider(4096))
            {
                try
                {
                               
                    rsa.FromXmlString(publicKey.ToString());

                    var encryptedData = rsa.Encrypt(testData, true);

                    var base64Encrypted = Convert.ToBase64String(encryptedData);

                    return base64Encrypted;
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
        #endregion
        public string Decryption(string strText)
        {
            var privateKey = "<RSAKeyValue><Modulus>21wEnTU+mcD2w0Lfo1Gv4rtcSWsQJQTNa6gio05AOkV/Er9w3Y13Ddo5wGtjJ19402S71HUeN0vbKILLJdRSES5MHSdJPSVrOqdrll/vLXxDxWs/U0UT1c8u6k/Ogx9hTtZxYwoeYqdhDblof3E75d9n2F0Zvf6iTb4cI7j6fMs=</Modulus><Exponent>AQAB</Exponent><P>/aULPE6jd5IkwtWXmReyMUhmI/nfwfkQSyl7tsg2PKdpcxk4mpPZUdEQhHQLvE84w2DhTyYkPHCtq/mMKE3MHw==</P><Q>3WV46X9Arg2l9cxb67KVlNVXyCqc/w+LWt/tbhLJvV2xCF/0rWKPsBJ9MC6cquaqNPxWWEav8RAVbmmGrJt51Q==</Q><DP>8TuZFgBMpBoQcGUoS2goB4st6aVq1FcG0hVgHhUI0GMAfYFNPmbDV3cY2IBt8Oj/uYJYhyhlaj5YTqmGTYbATQ==</DP><DQ>FIoVbZQgrAUYIHWVEYi/187zFd7eMct/Yi7kGBImJStMATrluDAspGkStCWe4zwDDmdam1XzfKnBUzz3AYxrAQ==</DQ><InverseQ>QPU3Tmt8nznSgYZ+5jUo9E0SfjiTu435ihANiHqqjasaUNvOHKumqzuBZ8NRtkUhS6dsOEb8A2ODvy7KswUxyA==</InverseQ><D>cgoRoAUpSVfHMdYXW9nA3dfX75dIamZnwPtFHq80ttagbIe4ToYYCcyUz5NElhiNQSESgS5uCgNWqWXt5PnPu4XmCXx6utco1UVH8HGLahzbAnSy6Cj3iUIQ7Gj+9gQ7PkC434HTtHazmxVgIR5l56ZjoQ8yGNCPZnsdYEmhJWk=</D></RSAKeyValue>";
           // privateKey = "<RSAKeyValue><Modulus>zhJtmTVrl/NBmQhJVGKtet9RFWZ4OHoLqblERGbVDLQyVS7r/1UCMwMSD5Gis/Uf0AJG/TE32S/2RCHs7KnKfCyDrTEksy9lRorkOlNf/c1DmqyceflrR3vOTDTTTu6k+rU3aslHKbs6VFaFg4x+Z1ogFu0/ZJD4esaTXwxn4FO0NWgsCsCMJTA6niURIpc2bxhRNKDivYdiaKXiCbjcAUzKShiQSkdB1wfZ0w4VH6456gPekQLS0Q8xP4t23M9fPQxgnVLtWfaeu92CzZ3I19dyZBuFcTFFmWbK2J5P+Lzipq6+ZhSHShWlk1ctihhW7ELxYtI3aLdMsZebW+EySijqT9UlJmY8aha3YsZmDq6T18Ih1k1CEW2/bWtxll/9BrpzORe2ja29EP1vRADjF7r7l6M9SwOAy9iuiz5CYYDcbrOS3e8j76KaNSxjzU+gh/KCFpuv8jrBGplAz9ync7PRQiaoiexLRyj3wCHWVNCkACvlAu5oGv/ZRdY7XRfTKM+6bKL01iGpkxYTLCScY77ADeimrdV89MaMES5J8u0l5/h9Da/S/eDqTJdl00NQSkhlpJKRs9I5js+1DzUwEr58J2ZWu9D7Xou0gYh2Bv+ojW/bbMBjQCWczByoGj7S7sR3ytFdgN0sYaCb7pGJO2+K5cVivaG4zX1Jcylaktk=</Modulus><Exponent>AQAB</Exponent><P>7CR2F8AQwfGWTEOFn9RNwgUq5AGanLR+RSEUDL35UT73J55s4NsApG6yXLyJNZloqyr7ff/Ixb3FBxRgwiuvBCZl0416esFhV2j7UPRx/NewM7dKwuCNR+TUCRwNb1u5Vzc7lZrWPZykvy4Egb5kIogEXvWm+5niPFYChvWIZL0K+uFoH2Y6FEcGcPFZPHSzTgd6FRLouMrkpZwuQzTG7cP1GLZu0rC3K/ogQvsYDtW8Jj9MuaesIoNzxnmOYsTiCEI8oPizV846oG0F3+vmy1UNSMhwhOLOTP2ZW75b912anD8xj1pyfPbUyN1l1ddtYFDSzmIUwhqM5ePSLw==</P><Q>32agqdq9TRwR7qb6nQTMRdUUCfsPV4u+yMU3e+kmoc5Ri2hkucBo/t0fHs4b4DfhOhtgpMykGRPk/WNwyjAOCMmk+UCS/XSTEtzRyd5D80gGUpXvvtyXs3sCbpJvuOnm+A4FU4uENKVdMDQVUupGJScDYqnf4GQVvb90TeQjDvcPcS3y408IcexN5ErndLiIFB4tfgbHQsHgayvRH/uM6oaNmZxED6FRSv3rsPlXjXYt09WcbSISy0dj3YdCtGo8t6NFnEdbYhHPEEsNSLTrgfpvZduLWEdkhJv3Tysg2yThIYqRffR6xx6g1GTLzqjZIZ8RgQzsU1Dp6OtISn1Rdw==</Q><DP>QvYz5pg4KEbxb77V7XSueA4vE2jBBx7Hj6LJpLNaN4e7Xii2hyyTCg251kJARkqyO5d8qUYXELu3W0KUDXuFrY+V4F+GE7kyeS7z1Qj8Kc6f0IpxUMGMTo688bhatvEzpV+sLcgyaFY7AVtzO7dZfdFELAlMyJviY2mgXdTSUH6q1mmEtSKv5YAee3h07YfKMJ4+KCusgnpGTA/1rmkQ3+tpXRCebHBgAMB01YmOUOaa692XTC4XydGsyuM9VRSvY9gkiSD8+jEovsUrnUuvrokEQVrsY28zOPt3tK1VB4b7XTHV3eitjREA1h7ISA1AC1uDUISawptdd40/1xC7UQ==</DP><DQ>UdyafQNRoMLrc0cuyIDslZ5J9IpSCeOEaq+R8E70QBCJYwtC9aojD1lZwQEHx/bSCmfj1x/B9gqLO6rHtt87FU9Gq6tU8ZlZF21hVpai0bAP2Q1mR8svr64gqwHv/JOBdl4053NVY7FA35wGQFbmk1CjdfEHv4MNUHWqmaxCiIZR20haG59nWc+cj04/WE8SVkTkqKy1Mao3oS3yOMUF0x6xHpvbeNrFHjTDvBryUTz/+ALrijYVKvYjCxc4g0H2s9gZdvXS77HU7YSC/qSFNCDf1zRG8HdgxxMb4Z/NL2BpOtA7FiuTHgoEJzA0WqsWvbI7SM3Cf5lDzX0CBYG8aw==</DQ><InverseQ>pRpg8lZEW1ydyzHCaMV0Bfh4aiwGf++lFku37RXzjymm92LebInUoABLmZRUO6TGZorKB9NpTfc/uh+RXLpCoogEIa0Z+O/vWrA5U0rQQHtIkYsfoNcKa0x5DKL24EzCFDrXgJES0gYYP/1reIcF55NM3NtEcUOOKRwiT4XscDFSNLzxrvhMxSEvE0RBsUabpzS249C2dgr5Bb3jX2q8QjDNwYameaK/Vqc6N17kiW2/wzxHzUa8D7BZpivbVVIL8bPYwFeIDy65n/+5+AjFOAJj45j1JHlos3av6RQ0lw3zRu2Xuz6KBeaZs1tsHOtxrHLlSIigEVnz3TpXBvantA==</InverseQ><D>JmSEitDLFOo7RHmov9IKpCPLBYOrzknetmZP87Z85vsDjZ9KVK3P1RUzXjcx6vk2Thi+hRmQYCRxa0wuygDwOqZIehH31nJ0GepyjvNNpQmDGOQj2w2/EPhd/RCydbg8gIEWrAyH95xsR54/Db01J6hA5kSZVPE1ehpZBpJXIBI4NuMLoY0yDxOnOCOLx7gIajZLmtSGqez5RqnxLQKF6rAV2CwvZcdU2u0ZhhrPkLFzFMhXxQiTomEN2SSZp00DzmpHmZ+1g3+kN26KvjEnIIFS+VcvTQC1YuzKxyDpcH7MDbKPlaAxiq2SHcrgtj6CNaIBnNH43iTD1tBlKKmLZlHzmh3k/HaQj/jMimSW1pcpb6QlmyWzKx21btdISc2m17isX07e0F+y+g1Ye5FyOWR+F37qUeIYXMaJwqf/++hERPDg1tFB1L9Vs4/C+29IEdaqc8jz12Jj5n5mvMEbtACzZBaGuJPq9gIq40hfu45Rbb27yC3KYM/cee9/cyoBJRJIOWMMsH6C8L9x6wf/5MRKROzSvA5sYnZ177RLTRDk+42YuKorsmWJaE8jgJdkxbVmtTVDp17KKyC/q2YqLIoY/NUxiyTJraVztaf34VckgeodDkWcRqQBzur5/x8hA378cSf42ldZp0LxWHR20GMNKZBbsD53Aqw3ik=</D></RSAKeyValue>";
            privateKey = @"<RSAKeyValue>
<Modulus>y2N/sDIZJXWGOEirIe+fQ30xI0hFWLzwfs6dwQa9hq/sBqnAXpaAl4oYgMX0RNxqHpSmFc4CiZaFfPhkW7XMIGfWaljCKnTTgTSo2gGW7F8CVjWhaETG0EZmBKp9vrY/Xb3rkn6MBO7VexpCIVdUJ1WBtIaIi1katjDw3CV+UGE2wElaAX2AzZQonRzwckjYRQLQWaz/MRL0po7KHc7hQ3ivcvx+JPeEgZko2AXAURQK6MPFj4HUSpZbLXTgUvEadiv7noCNTvZqcb7PZ6TEaCQme9K2B7RUBvc/DeIW7Qy+cvilEJWT3IPd0I0DG/cDzctftIE2DrJh7CBVeiVZq1mc8PMWVyf8lTq2JfW6g5usA0zm72+r7VwyPq5ShOxlV/UUJapRFVZ4SyUwnTkjIUskdNnb1TpFsFXFEFXwi9b4KSy3kmox7hFjEL6p0rE8w/JaTQeVCns++yCOivyAM/QmztfFhjAVBQUfPF4K0Euc7xRf1sS0V4SNo2SjHUDcfLOtoqFLHJSj1hPxdEAqHkBKYnOPaUHb3q/sQX3eGyR+P65REjy2rso4VX3e5Pwle9IWVos5wxvNouNnN3rJlb+fpjnZc6/DpofkjXAcm/6xtXNNJDsfUCGI6cYRIpd6dn/WkT2kQHUVYF1x5NqbCIJyEpVKU84NRb9EjiKCiO0=</Modulus>
<Exponent>AQAB</Exponent>
<P>zUhgIxFeZtcukI9C8eLU5sOL+cfRcmDt/vRmiFFQ7q+k96ezsquUIl0imiQthXApcHXngVBfRBQvVD1vSUr7qhL2KxN+2DRGdNhcuzQOkmmyicvjmojtnhC5GxET1NS1hG4N3WKTBqhVAfmRGJjw6LQmX1COnVA6dLSnkL1SboGz12r1UoM6g3dlfKM7MSZSGRgsB+dwwux3/gH5kYA+QyDN8veJr79fDdvonUsibqSg3PynSDG017gxwdRAqUX2I0i+RAtUEPKOkQfaMChpnVX+ieYWXcDfkaXRGKbX1AEAlbbncf9DwAOuoduIKV0xdccSQMxg/eTRLXisvGVDZw==</P>
<Q>/aNUS4t9u1BlgIzy3+fZaibfD6nmCyMpaPLyEW0nTTwKaudbjmCsefSdsqCFV/pUqd6A7T92yaoTcAhNkJiyVkNuoG1foEzIM+i8A8K/1YHWlBAwIF1loKc3pDGEXFTYbbosSf8cs/bd0rDBEYNMwRZ0DQc1swjTbxAq19lXPGEL0y72uHvTuhMcTZkUJMb4pEsPfD7fWiHQDbO17e8iOytUqzyLRYO9r0SslOkaJIne6orlag2WG2iFAed0u81RWTZq3stoN3iGYfG8273BCleiKUkEWXE95XTLj5pVwDi3ExeJQlK7NEgGFnRmoksnmTfn2nsC4mvNY/4tNFuQiw==</Q>
<DP>uwpD1g/gRLGxUrPFmmFD/NKVOkwPETkyAEgtF+2HYUMWezQI7jWZLkpP2cQ22csdZsN24QMbGguOKCIlwNEaRpcqRotn2pSe0Z3FuCgxUsQNkbH9OnOilY/FKN1BhX0duoEQDvPe5IUBl2AODSxk7JIgGF5s4vcTm/xyZNWrQtbYxuFEjx7UdK6YAJ01tI2m5gh5LeZ5fpE4r26bNzBzCnTcUZGrmT8z24vQAWlRASDtFQz7WjM4BAlnBKVhGRqOrw17lsH/ocVvksNl0NUxjdKprnm/TUMMMUe1IdH6+sbDAqZ5cQvVbiGsvvsosA+inh55CiNuCEexM84tDSby5w==</DP>
<DQ>L1vo6HYyUuBvI3KuAuraqLx7WARkRN4a5FLAqkpUVVKJq25ppQseCWOIcosQet3uIw29yw7Xkk4kdP3H5eDtI7hRlrj1awwLMc4aFSWvBiHJPDpNki1+RWITvJ/WVBsvkkV58ZMl++BziNyiIDABC+iyYKBhAX37ZLiDF2yookiImbUiMk5EuXDKDx8vKLLSSHMPgCaJM94uZ/CPXs8Q+DVeCN80LhWsPGa5RtDDpeDsc6Tds1C4H4QDmdhq7oomz16e09ztJ7ZkeTNXDTzAJ7s3NzhADKddZFPLkpPBwTOV04XIhk7GT7vHDzhK1bDswuoya5QedMKmRi52qFkUgw==</DQ>
<InverseQ>Gq/XCPuAhYxfwWI+HWCEm19QKz4jfFqimr7TfRf8NNwRmEx68NLsAxbsubSceKcx0d/Kalp2RP+eQEcU6gWpHOAylpiBNnuisMEfIViSOIAJNM8ssRplfAa0i/RdpNEFKjjGxuL3Cl2g15pQTXvO/KcaCDmfT8VRRM+BC3UHXYDk7MAjM3uZz+Ufowuc+4Z1sH0neR+NBAxWcWuYRda2WwYOHYNighK6qu7IkdoTS498x7ePFyz0MzZ7wTzHD4iOIAp66XKVT0DDBK3bViQVPFnyWNDnR6CSDngLvndSSiDLOxTga2GjPPBiKqcGHbXB/jif0cQJ2+9nIeWj7ohjkQ==</InverseQ>
<D>W8PTu6qO3/DLkx9uXwxfPjMA9ZtI9oWguIX+dTXWUyuSgVsbmVGsSTMcZRVrZZpRIuUMnm/pgyxvo/fqR9qZc9GF00uip0c4mmYo/NuUvacMRdtCrOnDDfuFUfueamqN4nyrCdig0iT0Guu5BJQDOxAASnQcrUqRm7wvIBSmjhueeVlfC6cVcyuyu1hwQBAPy+s+GAfOx9R2n6NzG8nYpvmPp4C2ZXVrypFQ9U56+9ngJi8WNu5r2w9Fqhe+ko2H0+N6ToRPvV2+nv1pVKjpmNceqeVjDczV0KLDRz9H+sIyN2tqBjaGlQrGDK9ixL5JcBOfZbCatDzVo5TfHBI4ByGDY/udV91EwpaDhu6f6gsll85v18MhKA5lsLN+LM9+xIj/FSJ/1L78Xs7QudeSUcbXR5Mtob70h4ILAZ7Jq1mIeTMnXD7i/5mU4nDy0y9FQBbZsH6hobjkcNF/U9dci+AAfhOrp/otI52LUpQFwxDR9jIuGi13dpvdnzTpZUk4eYrb4xiiziGMIxRyb2pj8UZxhoakU5zgSWRj3rD+QqZzm9tGSRxwz2eq3K8HG57oOMWGsRl9wLMReiO73SBwtZTh1q6IIjm1o1GeRXbnfXG2PKqFouNsJNzykUavKivCjZg1aYCrpTQ3SYNi9ELASlr7hgKeyqPn50HqOq/sZv0=</D>
</RSAKeyValue>";
            var testData = Encoding.UTF8.GetBytes(strText);

            using (var rsa = new RSACryptoServiceProvider(4096))
            {
                try
                {
                    var base64Encrypted = strText;

                                   
                    rsa.FromXmlString(privateKey);

                    var resultBytes = Convert.FromBase64String(base64Encrypted);
                    var decryptedBytes = rsa.Decrypt(resultBytes, true);
                    var decryptedData = Encoding.UTF8.GetString(decryptedBytes);
                    return decryptedData.ToString();
                }
                finally
                {
                    rsa.PersistKeyInCsp = false;
                }
            }
        }
    }
}
