using System.Collections.Generic;

namespace WalletServer.Rpc.Responses.RawTransactions
{
    
    public class Unknown
    {
        public KeyValuePair<string, string> key_hex { get; set; }
    }

    public class ScriptPubKey
    {
        public string asm { get; set; }
        public string hex { get; set; }
        public string type { get; set; }
        public string address { get; set; }
    }

    public class WitnessUtxo
    {
        public double amount { get; set; }
        public ScriptPubKey scriptPubKey { get; set; }
    }

    public class PartialSignatures
    {
        public string pubkey { get; set; }
    }

    public class RedeemScript
    {
        public string asm { get; set; }
        public string hex { get; set; }
        public string type { get; set; }
    }

    public class WitnessScript
    {
        public string asm { get; set; }
        public string hex { get; set; }
        public string type { get; set; }
    }

    public class Bip32Derivs
    {
        public string master_fingerprint { get; set; }
        public string path { get; set; }
        public string pubkey { get; set; }
    }

    public class FinalScriptsig
    {
        public string asm { get; set; }
        public string hex { get; set; }
    }

    public class PsbtInput
    {
        public object non_witness_utxo { get; set; }
        public WitnessUtxo witness_utxo { get; set; }
        public PartialSignatures partial_signatures { get; set; }
        public string sighash { get; set; }
        public RedeemScript redeem_script { get; set; }
        public WitnessScript witness_script { get; set; }
        public List<Bip32Derivs> bip32_derivs { get; set; }
        public FinalScriptsig final_scriptsig { get; set; }
        public List<string> final_scriptwitness { get; set; }
        public Unknown unknown { get; set; }
    }

    public class Output
    {
        public RedeemScript redeem_script { get; set; }
        public WitnessScript witness_script { get; set; }
        public List<Bip32Derivs> bip32_derivs { get; set; }
        public Unknown unknown { get; set; }
    }

    public class DecodePsbtResponse
    {
        public object tx { get; set; }
        public Unknown unknown { get; set; }
        public List<Input> inputs { get; set; }
        public List<Output> outputs { get; set; }
        public double fee { get; set; }
    }
}
