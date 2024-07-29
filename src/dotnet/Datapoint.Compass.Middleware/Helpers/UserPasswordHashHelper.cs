﻿namespace Datapoint.Compass.Middleware.Helpers
{
    internal static class UserPasswordHashHelper
    {
        private const bool BCryptEnhancedEntropy = true;

        private const BCrypt.Net.HashType BCryptHashType = BCrypt.Net.HashType.SHA384;

        private const char BCryptMinorRevision = 'b';

        internal static bool VerifyPassword(string password, string passwordHash) =>

            BCrypt.Net.BCrypt.Verify(
                password,
                passwordHash,
                BCryptEnhancedEntropy,
                BCryptHashType);

        internal static bool VerifyPasswordHash(string passwordHash, int workFactor) =>

            BCrypt.Net.BCrypt.PasswordNeedsRehash(
                passwordHash,
                workFactor);

        internal static string ComputePasswordHash(string password, int workFactor) =>

            BCrypt.Net.BCrypt.HashPassword(
                password,
                BCrypt.Net.BCrypt.GenerateSalt(
                    workFactor,
                    BCryptMinorRevision),
                BCryptEnhancedEntropy,
                BCryptHashType);
    }
}
