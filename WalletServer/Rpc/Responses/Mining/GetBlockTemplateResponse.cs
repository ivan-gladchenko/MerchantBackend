using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.Mining
{
    public class Vbavailable
    {
        public double rulename { get; set; }
    }

    public class Transaction
    {
        public string data { get; set; }
        public string txid { get; set; }
        public string hash { get; set; }
        public List<double> depends { get; set; }
        public double fee { get; set; }
        public double sigops { get; set; }
        public double weight { get; set; }
    }

    public class Coinbaseaux
    {
        public string key { get; set; }
    }

    public class GetBlockTemplateResponse
    {
        public double version { get; set; }
        public List<string> rules { get; set; }
        public Vbavailable vbavailable { get; set; }
        public double vbrequired { get; set; }
        public string previousblockhash { get; set; }
        public List<Transaction> transactions { get; set; }
        public Coinbaseaux coinbaseaux { get; set; }
        public double coinbasevalue { get; set; }
        public string longpollid { get; set; }
        public string target { get; set; }
        public int mintime { get; set; }
        public List<string> mutable { get; set; }
        public string noncerange { get; set; }
        public double sigoplimit { get; set; }
        public double sizelimit { get; set; }
        public double weightlimit { get; set; }
        public int curtime { get; set; }
        public string bits { get; set; }
        public double height { get; set; }
        public string default_witness_commitment { get; set; }
    }
}
