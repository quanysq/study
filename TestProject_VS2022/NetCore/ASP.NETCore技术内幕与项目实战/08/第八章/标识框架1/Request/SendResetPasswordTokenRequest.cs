public record SendResetPasswordTokenRequest(string Email);

public record ResetPasswordRequest(string Email, string Token, string NewPassword);
