using System.Collections.Generic;
using WalletServer.Rpc.Entities.Mining;
using WalletServer.Rpc.Entities.RawTransactions;
using WalletServer.Rpc.Entities.Wallet;
using WalletServer.Rpc.Responses.Blockchain;
using WalletServer.Rpc.Responses.Control;
using WalletServer.Rpc.Responses.Generating;
using WalletServer.Rpc.Responses.Mining;
using WalletServer.Rpc.Responses.Network;
using WalletServer.Rpc.Responses.RawTransactions;
using WalletServer.Rpc.Responses.Util;
using WalletServer.Rpc.Responses.Wallet;
using WalletServer.Rpc.Responses.Zmq;

namespace WalletServer.Rpc
{
    public interface ICoreService
    {
        string GetBestBlockHash();
        GetBlockVerbosity1Response GetBlock_Verbosity_1(string blockhash);
        GetBlockVerbosity2Response GetBlock_Verbosity_2(string blockhash);
        string GetBlock_Verbosity_0(string blockhash);
        GetBlockChainInfoResponse GetBlockChainInfo();
        long GetBlockCount();
        GetBlockFilterResponse GetBlockFilter(string blockhash, string filtertype = "basic");
        GetBlockHeaderResponse GetBlockHeader(string blockhash, bool verbose = true);
        GetBlockStatsResponse GetBlockStats(object hash_or_height, List<string> stats = null);
        List<GetChainTipsResponse> GetChainTips();
        GetChainTxStatsResponse GetChainTxStats(long nblocks = 30, string blockhash = "chain tip");
        double GetDifficulty();
        GetMempoolResponse GetMempoolAncestors_Verbose_True(string txid);
        List<string> GetMempoolAncestors_Verbose_False(string txid);
        GetMempoolResponse GetMempoolDescendants_Verbose_True(string txid);
        List<string> GetMempoolDescendants_Verbose_False(string txid);
        GetMempoolResponse GetMempoolEntry(string txid);
        GetMempoolInfoResponse GetMempoolInfo();
        GetMempoolResponse GetRawMempool_Verbose_True();
        List<string> GetRawMempool_Verbose_False();
        GetRawMempoolSequenceTrueResponse GetRawMempool_Sequence_True();
        GetTxOutResponse GetTxOut(string txid, long n, bool include_mempool = true);
        string GetTxOutpProof(List<string> txids, string blockhash = null);
        GetTxOutSetInfoResponse GetTxOutSetInfo(string hash_type = "hash_serialized_2");
        void PreciousBlock(string blockhash);
        long PruneBlockchain(long height);
        void SaveMempool();
        bool VerifyChain(long checklevel = 3, long nblocks = 6);
        List<string> VerifyTxOutProof(string proof);
        GetMemoryInfoResponse GetMemoryInfo(string mode = "stats");
        GetRpcInfoResponse GetRpcInfo();
        string Help();
        string Stop();
        double Uptime();
        GenerateBlockResponse GenerateBlock(string output, List<string> transactions);
        List<string> GenerateToAddress(long nblocks, string address, long maxtries = 1000000);
        List<string> GenerateToDescriptor(long num_blocks, string descriptor, long maxtries = 1000000);
        GetBlockTemplateResponse GetBlockTemplate(GetBlockTemplateRequest template_request = null);
        GetMiningInfoResponse GetMiningInfo();
        double GetNetworkHashPs(long nblocks = 120, long height = -1);
        bool PrioritiseTransaction(string txid, double fee_delta);
        void SubmitBlock(string hexdata);
        void SubmitHeader(string hexdata);
        void AddNode(string node, string command);
        void ClearBanned();
        void DisconnectNode(string address = null, long nodeId = 0);
        List<GetAddedNodeInfoResponse> GetAddedNodeInfoResponse(string node = null);
        long GetConnectionCount();
        GetNetTotalsResponse GetNetTotals();
        GetNetworkInfoResponse GetNetworkInfo();
        List<GetNodeAddressesResponse> GetNodeAddresses(long count = 1);
        List<GetPeerInfoResponse> GetPeerInfo();
        List<ListBannedResponse> ListBanned();
        void Ping();
        void SetBan(string subnet, string command, long bantime = 0, bool absolute = false);
        bool SetNetworkActive(bool state);
        AnalyzePsbtResponse AnalyzePsbt(string psbt);
        string CombinePsbt(List<string> txs);
        string CombineRawTransaction(List<string> txs);
        string ConvertToPsbt(string hexstring, bool permitsigdata = false, bool iswitness = false);

        string CreatePsbt(List<RawTransactionInput> inputs, Dictionary<string, double> outputs,
            long locktime = 0, bool replaceable = false);

        string CreateRawTransaction(List<RawTransactionInput> inputs, Dictionary<string, double> outputs,
            long locktime = 0, bool replaceable = false);

        DecodePsbtResponse DecodePsbt(string psbt);
        RawTransactionResponse DecodeRawTransaction(string hexstring, bool iswitness = false);
        DecodeScriptResponse DecodeScript(string hexstring);
        FinalizePsbtResponse FinalizePsbt(string psbt, bool extract = true);
        FundRawTransactionResponse FundRawTransaction(string hexstring, RawTransactionOptions options = null);
        RawTransactionResponse GetRawTransaction(string txid, bool verbose = false, string blockhash = "");
        string JoinPsbts(List<string> txs);
        string SendRawTransaction(string hexstring, double maxfeerate = 0.1);

        SignRawTransactionWithKeyResponse SignRawTransactionWithKey(string hexstring, List<string> privkeys,
            List<PrevTx> prevtxs = null);

        List<TestMempoolAcceptResponse> TestMempoolAccept(List<string> rawtxs, double maxfeerate = 0.1);
        string UtxoUpdatePsbt(string psbt, object descriptors = null);
        void AbandonTransaction(string txid);
        bool AbortRescan();
        AddMultiSigAddressResponse AddMultiSigAddress(int nrequired, List<string> addresses);
        BumpFeeResponse BumpFee(string txid);
        CreateWalletResponse CreateWallet(string walletName, bool disable_private_keys = false, bool blank = false, string passphrase = null, bool avoid_reuse = false, object load_on_startup = null);
        CreateWalletResponse CreateWallet(string walletName, bool disable_private_keys = false, bool blank = false);
        string DumpPrivKey(string address);
        string DumpWallet(string filename);
        string EncryptWallet(string passphrase);
        object GetAddessesByLabel(string label);
        GetAddressInfoResponse GetAddressInfo(string address);
        GetBalancesResponse GetBalances();
        string GetRawChangeAddress(string address_type = "legacy");
        double GetReceivedByAddress(string address, int minconf = 1);
        double GetReceivedByLabel(string label, int minconf = 1);
        GetTransactionResponse GetTransaction(string txid, bool include_watchonly = true, bool verbose = false);
        double GetUnconfirmedBalance();
        GetWalletInfoResponse GetWalletInfo();
        void ImportAddress(string address, string label, bool rescan = true, bool p2sh = false);
        ImportDescriptorsResponse ImportDescriptors(List<ImportDescriptorsObject> objects);
        ImportMultiResponse ImportMulti(List<ImportMultiObject> objects);
        void ImportPrivKey(string privkey, string label = "", bool rescan = true);
        void ImportPrunedFunds(string rawtransaction, string txoutproof);
        void ImportPubKey(string pubkey, string label = "", bool rescan = true);
        void ImportWallet(string filename);
        void KeyPoolRefill(long newsize = 100);
        List<List<List<object>>> ListAddressGroupings();
        List<string> ListLabels(string purpose = "");
        List<ListLockUnspentResponse> ListLockUnspent();

        List<ListReceivedByAddressResponse> ListReceivedByAddress(long minconf = 1, bool include_empty = false,
            bool include_watchonly = true, string address_filter = "");

        List<ListReceivedByLabelResponse> ListReceivedByLabel(long minconf = 1, bool include_empty = false,
            bool include_watchonly = true);

        ListSinceBlockResponse ListSinceBlock(string blockhash = null, long target_confirmations = 1,
            bool include_watchonly = true, bool include_removed = true);

        List<ListUnspentResponse> ListUnspent(long minconf = 1, long maxconf = 9999999, List<string> addresses = null,
            bool include_unsafe = true, ListUnspentQueryOptions query_options = null);

        ListWalletDirResponse ListWalletDir();
        List<string> ListWallets();
        LoadWalletResponse LoadWallet(string filename);
        bool LockUnspent(bool unlock, List<LockUnspentTransaction> transactions = null);
        PsbtBumpFeeResponse PsbtBumpFee(string txid, PsbtBumpFeeOptions options = null);
        void RemovePrunedFunds(string txid);
        RescanBlockchainResponse RescanBlockchain(long start_height = 0, long stop_height = long.MaxValue);

        SendResponse Send(Dictionary<string, double> outputs, long conf_target = 0,
            string estimate_mode = "unset", double fee_rate = 100, SendOptions options = null);

        SendManyResponse SendMany(Dictionary<string, double> amounts, object minconf = null,
            string comment = null, List<string> subtractfeefrom = null, bool replaceable = true,
            object conf_target = null, string estimate_mode = "unset", object fee_rate = null,
            bool verbose = false);

        double GetBalance(string dummy, short confirmations = 0);
        double GetBalance();
        void BackupWallet(string path);
        List<ListTransactionsResponse> ListTransactions(string label = "*", int count = 10, int skip = 0, bool watchonly = false);
        string GetNewAddress();
        void SetHdSeed(bool newkeypool = true, string seed = "1984");
        void SetLabel(string address, string label);
        SetWalletFlagResponse SetWalletFlag(string flag, bool value = true);
        string SignMessage(string address, string message);

        SignRawTransactionWithWalletResponse SignRawTransactionWithWallet(string hexstring,
            List<PrevTxsOptions> prevtxs = null, string sighashtype = "ALL");

        UnloadWalletResponse UnloadWallet(string wallet_name = "", object load_on_startup = null);
        UpgradeWalletResponse UpgradeWallet(long version = 169900);

        WalletCreateFundedPsbtResponse WalletCreateFundedPsbt(List<RawTransactionInput> inputs,
            Dictionary<string, double> outputs,
            long locktime = 0,
            RawTransactionOptions options = null,
            bool bip32derivs = true);

        void WalletLock();
        void WalletPassphraseChange(string oldpassphrase, string newpassphrase);

        WalletProcessPsbtResponse WalletProcessPsbt(string psbt, bool sign = true, string signhastype = "ALL",
            bool bip32derivs = true);

        bool SetTxFee(double fee);
        void WalletPassphrase(string passphrase, int timeout);
        string SendToAddress(string address, double amount);
        double EstimateSmartFee(int nblocks);

        CreateMultiSigResponse
            CreateMultiSig(long nrequired, List<string> keys, string address_type = "legacy");

        List<string> DeriveAddresses(string descriptor, object range = null);
        GetDescriptorInfoResponse GetDescriptorInfo(string descriptor);
        GetIndexInfoResponse GetIndexInfo(string index_name = "");
        string SignMessageWithPrivateKey(string privkey, string message);
        ValidateAddressResponse ValidateAddress(string address);
        bool VerifyMessage(string address, string signature, string message);
        List<GetZmqNotificationsResponse> GetZmqNotifications();
    }
}
