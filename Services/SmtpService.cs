namespace Services
{
    
    public interface ISmtpService
    {
        SmtpSettings GetSmtpSettings();
    }
    public class SmtpService : ISmtpService
    {
        private readonly SmtpSettings smtpSettings;
        private readonly IConfiguration _configuration;
        public SmtpService(IConfiguration configuration)
        {
            _configuration = configuration;
            smtpSettings = new SmtpSettings();
        }

        public SmtpSettings GetSmtpSettings()
        {
            SetSmtpSettings();
            return smtpSettings;
        }

        public void SetSmtpSettings()
        {
            //Check if env is dev or prod
            if (_configuration.GetValue<string>("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                //Dev settings
                smtpSettings.Server = _configuration["Smtp:Server"];
                smtpSettings.Port = int.Parse(_configuration["Smtp:Port"]);
                smtpSettings.Username = _configuration["Smtp:Username"];
                smtpSettings.Password = _configuration["Smtp:Password"];
                smtpSettings.UseSsl = bool.Parse(_configuration["Smtp:UseSsl"]);
            }
            else
            {
                //Prod settings
                smtpSettings.Server = _configuration["SMTP_Server"];
                smtpSettings.Port = int.Parse(_configuration["SMTP_Port"]);
                smtpSettings.Username = _configuration["SMTP_Username"];
                smtpSettings.Password = _configuration["SMTP_Password"];
                smtpSettings.UseSsl = bool.Parse(_configuration["SMTP_UseSsl"]);
            }
        }
    }
}