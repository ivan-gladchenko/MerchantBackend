using System.Collections.Generic;
using WalletServer.Rpc.Entities.Mining;
using WalletServer.Rpc.Entities.RawTransactions;
using WalletServer.Rpc.Entities.Wallet;
using WalletServer.Rpc.Handler;
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
    public abstract class CoreService : ICoreService
    {
        private protected readonly RpcHandler Handler;

        protected CoreService(string address, string login, string password)
        {
            Handler = new RpcHandler(address, login, password);
        }
        protected CoreService(string address)
        {
            Handler = new RpcHandler(address);
        }

        protected CoreService(string address, string wallet, string login, string password)
        {
            Handler = new RpcHandler(address, login, password, wallet);
        }

        #region blockchain

        public string GetBestBlockHash() => Handler.Send<string>("getbestblockhash", null).result;

        public GetBlockVerbosity1Response GetBlock_Verbosity_1(string blockhash) =>
             Handler.Send<GetBlockVerbosity1Response>("getblock", new object[] {blockhash, 1}).result;
        public GetBlockVerbosity2Response GetBlock_Verbosity_2(string blockhash) =>
            Handler.Send<GetBlockVerbosity2Response>("getblock", new object[] { blockhash, 2 }).result;
        public string GetBlock_Verbosity_0(string blockhash) =>
            Handler.Send<string>("getblock", new object[] { blockhash, 0 }).result;
        public GetBlockChainInfoResponse GetBlockChainInfo() =>
            Handler.Send<GetBlockChainInfoResponse>("getblockchaininfo", null).result;
        public long GetBlockCount() => Handler.Send<long>("getblockcount", null).result;
        public GetBlockFilterResponse GetBlockFilter(string blockhash, string filtertype = "basic") => Handler
            .Send<GetBlockFilterResponse>("getblockfilter", new object[] {blockhash, filtertype}).result;
        public GetBlockHeaderResponse GetBlockHeader(string blockhash, bool verbose = true) => Handler
            .Send<GetBlockHeaderResponse>("getblockheader", new object[] {blockhash, verbose}).result;
        public GetBlockStatsResponse GetBlockStats(object hash_or_height, List<string> stats = null) => Handler
            .Send<GetBlockStatsResponse>("getblockstats", new object[] {hash_or_height, stats}).result;
        public List<GetChainTipsResponse> GetChainTips() =>
            Handler.Send<List<GetChainTipsResponse>>("getchaintips", null).result;
        public GetChainTxStatsResponse GetChainTxStats(long nblocks = 30, string blockhash = "chain tip") => Handler
            .Send<GetChainTxStatsResponse>("getchaintxstats", new object[] {nblocks, blockhash}).result;
        public double GetDifficulty() => Handler.Send<double>("getdifficulty", null).result;
        public GetMempoolResponse GetMempoolAncestors_Verbose_True(string txid) => Handler
            .Send<GetMempoolResponse>("getmempoolancestors", new object[] {txid, true}).result;
        public List<string> GetMempoolAncestors_Verbose_False(string txid) => Handler
            .Send<List<string>>("getmempoolancestors", new object[] { txid, false }).result;
        public GetMempoolResponse GetMempoolDescendants_Verbose_True(string txid) => Handler
            .Send<GetMempoolResponse>("getmempooldescendants", new object[] { txid, true }).result;
        public List<string> GetMempoolDescendants_Verbose_False(string txid) => Handler
            .Send<List<string>>("getmempooldescendants", new object[] { txid, false }).result;
        public GetMempoolResponse GetMempoolEntry(string txid) =>
            Handler.Send<GetMempoolResponse>("getmempoolentry", new object[] {txid}).result;
        public GetMempoolInfoResponse GetMempoolInfo() =>
            Handler.Send<GetMempoolInfoResponse>("getmempoolinfo", null).result;
        public GetMempoolResponse GetRawMempool_Verbose_True() => Handler
            .Send<GetMempoolResponse>("getrawmempool ", new object[] { true, false }).result;
        public List<string> GetRawMempool_Verbose_False() => Handler
            .Send<List<string>>("getrawmempool ", new object[] { false, false }).result;
        public GetRawMempoolSequenceTrueResponse GetRawMempool_Sequence_True() => Handler
            .Send<GetRawMempoolSequenceTrueResponse>("getrawmempool ", new object[] { false, true }).result;
        public GetTxOutResponse GetTxOut(string txid, long n, bool include_mempool = true) =>
            Handler.Send<GetTxOutResponse>("gettxout", new object[] {txid, n, include_mempool}).result;

        public string GetTxOutpProof(List<string> txids, string blockhash = null) =>
            Handler.Send<string>("gettxoutproof", new object[] {txids, blockhash}).result;

        public GetTxOutSetInfoResponse GetTxOutSetInfo(string hash_type = "hash_serialized_2") =>
            Handler.Send<GetTxOutSetInfoResponse>("gettxoutsetinfo", new object[] {hash_type}).result;

        public void PreciousBlock(string blockhash) => Handler.Send<string>("preciousblock", new object[] {blockhash});
        public long PruneBlockchain(long height) => Handler.Send<long>("pruneblockchain", new object[]{height}).result;
        public void SaveMempool() => Handler.Send<string>("savemempool", null);
        // scantxoutset wip
        public bool VerifyChain(long checklevel = 3, long nblocks = 6) =>
            Handler.Send<bool>("verifychain", new object[] {checklevel, nblocks}).result;

        public List<string> VerifyTxOutProof(string proof) =>
            Handler.Send<List<string>>("verifytxoutproof", new object[] {proof}).result;
        #endregion

        #region control

        public GetMemoryInfoResponse GetMemoryInfo(string mode = "stats") =>
            Handler.Send<GetMemoryInfoResponse>("getmemoryinfo", new object[] {mode}).result;

        public GetRpcInfoResponse GetRpcInfo() => Handler.Send<GetRpcInfoResponse>("getrpcinfo", null).result;
        public string Help() => Handler.Send<string>("help", null).result;
        //logging wip
        public string Stop() => Handler.Send<string>("stop", null).result;
        public double Uptime() => Handler.Send<double>("uptime", null).result;
        #endregion

        #region generating

        public GenerateBlockResponse GenerateBlock(string output, List<string> transactions) => Handler.Send<GenerateBlockResponse>("generateblock", new object[]{output, transactions}).result;

        public List<string> GenerateToAddress(long nblocks, string address, long maxtries = 1000000) => Handler
            .Send<List<string>>("generatetoaddress", new object[] {nblocks, address, maxtries}).result;
        public List<string> GenerateToDescriptor(long num_blocks, string descriptor, long maxtries = 1000000) => Handler
            .Send<List<string>>("generatetoaddress", new object[] { num_blocks, descriptor, maxtries }).result;
        #endregion

        #region mining

        public GetBlockTemplateResponse GetBlockTemplate(GetBlockTemplateRequest template_request = null) => Handler
            .Send<GetBlockTemplateResponse>("getblocktemplate", new object[] {template_request}).result;

        public GetMiningInfoResponse GetMiningInfo() =>
            Handler.Send<GetMiningInfoResponse>("getmininginfo", null).result;

        public double GetNetworkHashPs(long nblocks = 120, long height = -1) =>
            Handler.Send<double>("getnetworkhashps", new object[] {nblocks, height}).result;

        public bool PrioritiseTransaction(string txid, double fee_delta) =>
            Handler.Send<bool>("prioritisetransaction", new object[] {txid, 0, fee_delta}).result;

        public void SubmitBlock(string hexdata) =>
            Handler.Send<string>("submitblock", new object[] {hexdata, "ignored"});

        public void SubmitHeader(string hexdata) => Handler.Send<string>("submitheader", new object[] {hexdata});
        #endregion

        #region network

        public void AddNode(string node, string command) =>
            Handler.Send<string>("addnode", new object[] {node, command});

        public void ClearBanned() => Handler.Send<string>("clearbanned", null);

        public void DisconnectNode(string address = null, long nodeId = 0) =>
            Handler.Send<string>("disconnectnode", new object[] {address, nodeId});

        public List<GetAddedNodeInfoResponse> GetAddedNodeInfoResponse(string node = null) => Handler
            .Send<List<GetAddedNodeInfoResponse>>("getaddednodeinfo", new object[] {node}).result;

        public long GetConnectionCount() => Handler.Send<long>("getconnectioncount", null).result;
        public GetNetTotalsResponse GetNetTotals() => Handler.Send<GetNetTotalsResponse>("getnettotals", null).result;

        public GetNetworkInfoResponse GetNetworkInfo() =>
            Handler.Send<GetNetworkInfoResponse>("getnetworkinfo", null).result;

        public List<GetNodeAddressesResponse> GetNodeAddresses(long count = 1) =>
            Handler.Send<List<GetNodeAddressesResponse>>("getnodeaddresses", new object[] {count}).result;

        public List<GetPeerInfoResponse> GetPeerInfo() =>
            Handler.Send<List<GetPeerInfoResponse>>("getpeerinfo", null).result;

        public List<ListBannedResponse> ListBanned() =>
            Handler.Send<List<ListBannedResponse>>("listbanned", null).result;

        public void Ping() => Handler.Send<string>("ping", null);

        public void SetBan(string subnet, string command, long bantime = 0, bool absolute = false) =>
            Handler.Send<string>("setban", new object[] {subnet, command, bantime, absolute});

        public bool SetNetworkActive(bool state) =>
            Handler.Send<bool>("setnetworkactive", new object[] {state}).result;
        #endregion

        #region rawtransactions

        public AnalyzePsbtResponse AnalyzePsbt(string psbt) =>
            Handler.Send<AnalyzePsbtResponse>("analyzepsbt", new object[] {psbt}).result;
        public string CombinePsbt(List<string> txs) => Handler.Send<string>("combinepsbt", new object[] {txs}).result;
        public string CombineRawTransaction(List<string> txs) => Handler.Send<string>("combinerawtransaction", new object[] { txs }).result;

        public string ConvertToPsbt(string hexstring, bool permitsigdata = false, bool iswitness = false) => Handler
            .Send<string>("converttopsbt", new object[] {hexstring, permitsigdata, iswitness}).result;

        public string CreatePsbt(List<RawTransactionInput> inputs, Dictionary<string, double> outputs,
            long locktime = 0, bool replaceable = false) => Handler
            .Send<string>("createpsbt", new object[] {inputs, outputs, locktime, replaceable}).result;
        public string CreateRawTransaction(List<RawTransactionInput> inputs, Dictionary<string, double> outputs,
            long locktime = 0, bool replaceable = false) => Handler.Send<string>("createrawtransaction",
            new object[] {inputs, outputs, locktime, replaceable}).result;
        public DecodePsbtResponse DecodePsbt(string psbt) =>
            Handler.Send<DecodePsbtResponse>("decodepsbt", new object[] {psbt}).result;

        public RawTransactionResponse DecodeRawTransaction(string hexstring, bool iswitness = false) => Handler
            .Send<RawTransactionResponse>("decoderawtransaction", new object[] {hexstring, iswitness}).result;

        public DecodeScriptResponse DecodeScript(string hexstring) =>
            Handler.Send<DecodeScriptResponse>("decodescript", new object[] {hexstring}).result;

        public FinalizePsbtResponse FinalizePsbt(string psbt, bool extract = true) =>
            Handler.Send<FinalizePsbtResponse>("finalizepsbt", new object[] {psbt, extract}).result;

        public FundRawTransactionResponse FundRawTransaction(string hexstring, RawTransactionOptions options = null) =>
            Handler.Send<FundRawTransactionResponse>("fundrawtransaction", new object[] {hexstring, options}).result;

        public RawTransactionResponse GetRawTransaction(string txid, bool verbose = false, string blockhash = "") =>
            Handler.Send<RawTransactionResponse>("getrawtransaction", new object[] {txid, verbose, blockhash}).result;

        public string JoinPsbts(List<string> txs) => Handler.Send<string>("joinpsbts", new object[] {txs}).result;

        public string SendRawTransaction(string hexstring, double maxfeerate = 0.1) =>
            Handler.Send<string>("sendrawtransaction", new object[] {hexstring, maxfeerate}).result;

        public SignRawTransactionWithKeyResponse SignRawTransactionWithKey(string hexstring, List<string> privkeys,
            List<PrevTx> prevtxs = null) => Handler
            .Send<SignRawTransactionWithKeyResponse>("signrawtransactionwithkey",
                new object[] {hexstring, privkeys, prevtxs}).result;

        public List<TestMempoolAcceptResponse> TestMempoolAccept(List<string> rawtxs, double maxfeerate = 0.1) => Handler
            .Send<List<TestMempoolAcceptResponse>>("testmempoolaccept", new object[] {rawtxs, maxfeerate}).result;

        public string UtxoUpdatePsbt(string psbt, object descriptors = null) =>
            Handler.Send<string>("utxoupdatepsbt", new object[] {psbt, descriptors}).result;
        #endregion

        #region wallet
        public void AbandonTransaction(string txid) => Handler.Send<string>("abandontransaction", new object[] {txid});
        public bool AbortRescan() => Handler.Send<bool>("abortrescan", null).result;
        public AddMultiSigAddressResponse AddMultiSigAddress(int nrequired, List<string> addresses) => Handler
            .Send<AddMultiSigAddressResponse>("addmultisigaddress", new object[] {nrequired, addresses.ToArray()}).result;
        public BumpFeeResponse BumpFee(string txid) =>
            Handler.Send<BumpFeeResponse>("bumpfee", new object[] {txid}).result;
        public CreateWalletResponse CreateWallet(string walletName, bool disable_private_keys = false, bool blank =  false, string passphrase = null, bool avoid_reuse = false, object load_on_startup = null) =>
            Handler.Send<CreateWalletResponse>("createwallet", new object[] {walletName, disable_private_keys, blank, passphrase, avoid_reuse, load_on_startup}).result;
        public CreateWalletResponse CreateWallet(string walletName, bool disable_private_keys = false, bool blank = false) =>
            Handler.Send<CreateWalletResponse>("createwallet", new object[] { walletName, disable_private_keys, blank}).result;
        public string DumpPrivKey(string address) =>
            Handler.Send<string>("dumpprivkey", new object[] {address}).result;
        public string DumpWallet(string filename) =>
            Handler.Send<string>("dumpwallet", new object[] {filename}).result;
        public string EncryptWallet(string passphrase) =>
            Handler.Send<string>("encryptwallet", new object[] {passphrase}).result;
        public object GetAddessesByLabel(string label) =>
            Handler.Send<object>("getaddressesbylabel", new object[] {label}).result;
        public GetAddressInfoResponse GetAddressInfo(string address) =>
            Handler.Send<GetAddressInfoResponse>("getaddressinfo", new object[] {address}).result;
        public GetBalancesResponse GetBalances() => Handler.Send<GetBalancesResponse>("getbalances", null).result;
        public string GetRawChangeAddress(string address_type = "legacy") =>
            Handler.Send<string>("getrawchangeaddress", new object[] {address_type}).result;
        public double GetReceivedByAddress(string address, int minconf = 1) =>
            Handler.Send<double>("getreceivedbyaddress", new object[] {address, minconf}).result;
        public double GetReceivedByLabel(string label, int minconf = 1) =>
            Handler.Send<double>("getreceivedbylabel", new object[] { label, minconf }).result;
        public GetTransactionResponse GetTransaction(string txid, bool include_watchonly = true, bool verbose = false) => 
            Handler.Send<GetTransactionResponse>("gettransaction", new object[] {txid, include_watchonly, verbose}).result;
        public double GetUnconfirmedBalance() => Handler.Send<double>("getunconfirmedbalance", null).result;
        public GetWalletInfoResponse GetWalletInfo() =>
            Handler.Send<GetWalletInfoResponse>("getwalletinfo", null).result;
        public void ImportAddress(string address, string label, bool rescan = true, bool p2sh = false) =>
            Handler.Send<string>("importaddress", new object[] {address, label, rescan, p2sh});
        public ImportDescriptorsResponse ImportDescriptors(List<ImportDescriptorsObject> objects) =>
            Handler.Send<ImportDescriptorsResponse>("importdescriptors", objects).result;
        public ImportMultiResponse ImportMulti(List<ImportMultiObject> objects) =>
            Handler.Send<ImportMultiResponse>("importmulti", objects).result;
        public void ImportPrivKey(string privkey, string label = "", bool rescan = true) =>
            Handler.Send<string>("importprivkey", new object[] {privkey, label, rescan});
        public void ImportPrunedFunds(string rawtransaction, string txoutproof) =>
            Handler.Send<string>("importprunedfunds", new object[] {rawtransaction, txoutproof});
        public void ImportPubKey(string pubkey, string label = "", bool rescan = true) =>
            Handler.Send<string>("importpubkey", new object[] {pubkey, label, rescan});
        public void ImportWallet(string filename) => Handler.Send<string>("importwallet", new object[] {filename});
        public void KeyPoolRefill(long newsize = 100) => Handler.Send<string>("keypoolrefill", new object[] {newsize});
        public List<List<List<object>>> ListAddressGroupings() =>
            Handler.Send<List<List<List<object>>>>("listaddressgroupings", null).result;
        public List<string> ListLabels(string purpose = "") =>
            Handler.Send<List<string>>("listlabels", new object[] {purpose}).result;
        public List<ListLockUnspentResponse> ListLockUnspent() =>
            Handler.Send<List<ListLockUnspentResponse>>("listlockunspent", null).result;
        public List<ListReceivedByAddressResponse> ListReceivedByAddress(long minconf = 1, bool include_empty = false,
            bool include_watchonly = true, string address_filter = "") => Handler
            .Send<List<ListReceivedByAddressResponse>>("listreceivedbyaddress",
                new object[] {minconf, include_empty, include_watchonly, address_filter}).result;
        public List<ListReceivedByLabelResponse> ListReceivedByLabel(long minconf = 1, bool include_empty = false,
            bool include_watchonly = true) => Handler
            .Send<List<ListReceivedByLabelResponse>>("listreceivedbylabel",
                new object[] { minconf, include_empty, include_watchonly }).result;
        public ListSinceBlockResponse ListSinceBlock(string blockhash = null, long target_confirmations = 1,
            bool include_watchonly = true, bool include_removed = true) => Handler
            .Send<ListSinceBlockResponse>("listsinceblock",
                new object[] {blockhash, target_confirmations, include_watchonly, include_removed}).result;
        public List<ListUnspentResponse> ListUnspent(long minconf = 1, long maxconf = 9999999, List<string> addresses = null,
            bool include_unsafe = true, ListUnspentQueryOptions query_options = null) => Handler
            .Send<List<ListUnspentResponse>>("listunspent",
                new object[] {minconf, maxconf, addresses, include_unsafe, query_options}).result;
        public ListWalletDirResponse ListWalletDir() =>
            Handler.Send<ListWalletDirResponse>("listwalletdir", null).result;
        public List<string> ListWallets(){

            return Handler.Send<List<string>>("listwallets", null, true).result;
        }
        public LoadWalletResponse LoadWallet(string filename, object load_on_startup = null) => Handler
            .Send<LoadWalletResponse>("loadwallet", new object[] {filename, load_on_startup}).result;
        public bool LockUnspent(bool unlock, List<LockUnspentTransaction> transactions = null) =>
            Handler.Send<bool>("lockunspent", new object[] {unlock, transactions}).result;
        public PsbtBumpFeeResponse PsbtBumpFee(string txid, PsbtBumpFeeOptions options = null) =>
            Handler.Send<PsbtBumpFeeResponse>("psbtbumpfee", new object[] {txid, options}).result;
        public void RemovePrunedFunds(string txid) => Handler.Send<string>("removeprunedfunds", new object[] {txid});
        public RescanBlockchainResponse RescanBlockchain(long start_height = 0, long stop_height = long.MaxValue) =>
            Handler.Send<RescanBlockchainResponse>("rescanblockchain", new object[] {start_height, start_height})
                .result;
        public SendResponse Send(Dictionary<string, double> outputs, long conf_target = 0,
            string estimate_mode = "unset", double fee_rate = 100, SendOptions options = null) => Handler
            .Send<SendResponse>("send", new object[] {outputs, conf_target, estimate_mode, fee_rate, options}).result;
        public SendManyResponse SendMany(Dictionary<string, double> amounts, object minconf = null,
            string comment = null, List<string> subtractfeefrom = null, bool replaceable = true,
            object conf_target = null, string estimate_mode = "unset", object fee_rate = null,
            bool verbose = false) => Handler.Send<SendManyResponse>("sendmany",
            new[]
            {
                "", amounts, minconf, comment, subtractfeefrom, replaceable, conf_target,
                estimate_mode, fee_rate, verbose
            }).result;
        public double GetBalance(string dummy, short confirmations = 0)
        {
            return Handler.Send<double>("getbalance", new object[] { dummy, confirmations }).result;
        }
        public double GetBalance() => Handler.Send<double>("getbalance", null).result;
        public void BackupWallet(string path) => Handler.Send<string>("backupwallet", new object[] { path });

        public List<ListTransactionsResponse> ListTransactions(string label = "*", int count = 10, int skip = 0, bool watchonly = false) => Handler
            .Send<List<ListTransactionsResponse>>("listtransactions", new object[] { label, count, skip, watchonly }).result;
        public string GetNewAddress() => Handler.Send<string>("getnewaddress", null).result;
        public void SetHdSeed(bool newkeypool = true, string seed = "1984") =>
            Handler.Send<string>("sethdseed", new object[] {newkeypool, seed});
        public void SetLabel(string address, string label) =>
            Handler.Send<string>("setlabel", new object[] {address, label});
        public SetWalletFlagResponse SetWalletFlag(string flag, bool value = true) =>
            Handler.Send<SetWalletFlagResponse>("setwalletflag", new object[] {flag, value}).result;
        public string SignMessage(string address, string message) =>
            Handler.Send<string>("signmessage", new object[] {address, message}).result;
        public SignRawTransactionWithWalletResponse SignRawTransactionWithWallet(string hexstring,
            List<PrevTxsOptions> prevtxs = null, string sighashtype = "ALL") => Handler
            .Send<SignRawTransactionWithWalletResponse>("signrawtransactionwithwallet", new object[] {hexstring, prevtxs, sighashtype})
            .result;
        public UnloadWalletResponse UnloadWallet(string wallet_name = "", object load_on_startup = null) => Handler
            .Send<UnloadWalletResponse>("unloadwallet", new object[] {wallet_name, load_on_startup}).result;
        public UpgradeWalletResponse UpgradeWallet(long version = 169900) =>
            Handler.Send<UpgradeWalletResponse>("upgradewallet", new object[] {version}).result;
        public WalletCreateFundedPsbtResponse WalletCreateFundedPsbt(List<RawTransactionInput> inputs,
            Dictionary<string, double> outputs,
            long locktime = 0,
            RawTransactionOptions options = null,
            bool bip32derivs = true) =>
            Handler.Send<WalletCreateFundedPsbtResponse>("walletcreatefundedpsbt",
                new object[] { inputs, outputs, locktime, options, bip32derivs}).result;
        public void WalletLock() => Handler.Send<string>("walletlock", null);
        public void WalletPassphraseChange(string oldpassphrase, string newpassphrase) =>
            Handler.Send<string>("walletpassphrasechange", new object[] {oldpassphrase, newpassphrase});
        public WalletProcessPsbtResponse WalletProcessPsbt(string psbt, bool sign = true, string signhastype = "ALL",
            bool bip32derivs = true) => Handler.Send<WalletProcessPsbtResponse>("walletprocesspsbt",
            new object[] {psbt, sign, signhastype, bip32derivs}).result;
        public bool SetTxFee(double fee) => Handler.Send<bool>("settxfee", new object[] { fee }).result;
        public void WalletPassphrase(string passphrase, int timeout) =>
            Handler.Send<string>("walletpassphrase", new object[] { passphrase, timeout });
        public string SendToAddress(string address, double amount) =>
            Handler.Send<string>("sendtoaddress", new object[] { address, amount }).result;
        #endregion

        #region util

        public double EstimateSmartFee(int nblocks) => Handler.Send<FeeRateResponse>("estimatesmartfee", new object[] { nblocks }).result.feerate;
        public CreateMultiSigResponse
            CreateMultiSig(long nrequired, List<string> keys, string address_type = "legacy") => Handler
            .Send<CreateMultiSigResponse>("createmultisig", new object[] {nrequired, keys, address_type}).result;
        public List<string> DeriveAddresses(string descriptor, object range = null) =>
            Handler.Send<List<string>>("deriveaddresses", new object[] {descriptor, range}).result;
        public GetDescriptorInfoResponse GetDescriptorInfo(string descriptor) => Handler
            .Send<GetDescriptorInfoResponse>("getdescriptorinfo", new object[] {descriptor}).result;
        public GetIndexInfoResponse GetIndexInfo(string index_name = "") =>
            Handler.Send<GetIndexInfoResponse>("getindexinfo", new object[] {index_name}).result;
        public string SignMessageWithPrivateKey(string privkey, string message) =>
            Handler.Send<string>("signmessagewithprivkey", new object[] {privkey, message}).result;
        public ValidateAddressResponse ValidateAddress(string address) =>
            Handler.Send<ValidateAddressResponse>("validateaddress", new object[] {address}).result;
        public bool VerifyMessage(string address, string signature, string message) =>
            Handler.Send<bool>("verifymessage", new object[] {address, signature, message}).result;
        #endregion

        #region zmq

        public List<GetZmqNotificationsResponse> GetZmqNotifications() =>
            Handler.Send<List<GetZmqNotificationsResponse>>("getzmqnotifications", null).result;

        #endregion
    }
}
