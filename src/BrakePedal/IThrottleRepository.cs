namespace BrakePedal
{
    public interface IThrottleRepository
    {
        object[] PolicyIdentityValues { get; set; }

        long? GetThrottleCount(IThrottleKey key, Limiter limiter);

        void AddOrIncrementWithExpiration(IThrottleKey key, Limiter limiter);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="limiter"></param>
        void SetLock(IThrottleKey key, Limiter limiter);

        /// <summary>
        /// Check if a lock for a given key exists in the storage
        /// </summary>
        /// <param name="key"></param>
        /// <param name="limiter"></param>
        /// <returns></returns>
        bool LockExists(IThrottleKey key, Limiter limiter);

        void RemoveThrottle(IThrottleKey key, Limiter limiter);

        string CreateThrottleKey(IThrottleKey key, Limiter limiter);

        string CreateLockKey(IThrottleKey key, Limiter limiter);
    }
}