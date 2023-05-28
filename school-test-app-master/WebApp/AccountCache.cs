using System.Collections.Concurrent;

namespace WebApp
{
    class AccountCache : IAccountCache
    {
        private readonly ConcurrentDictionary<long, Account> _itemsById = new ConcurrentDictionary<long, Account>();
        private readonly ConcurrentDictionary<string, long> _idByGuid = new ConcurrentDictionary<string, long>();

        public bool TryGetValue(long accountId, out Account item)
        {
            return _itemsById.TryGetValue(accountId, out item);
        }

        public bool TryGetValue(string externalId, out Account item)
        {
            item = null;
            if (_idByGuid.TryGetValue(externalId, out var accountId))
            {
                return _itemsById.TryGetValue(accountId, out item);
            }
            return false;
        }

        public void AddOrUpdate(Account account)
        {
            _itemsById.AddOrUpdate(account.InternalId, account, (key, oldValue) => account);
            _idByGuid.AddOrUpdate(account.ExternalId, account.InternalId, (key, oldValue) => account.InternalId);
        }

        public bool TryRemove(long key, out Account account)
        {
            if (_itemsById.TryRemove(key, out account))
            {
                _idByGuid.TryRemove(account.ExternalId, out _);
                return true;
            }
            return false;
        }

        public void Clear()
        {
            _itemsById.Clear();
            _idByGuid.Clear();
        }
    }
}
