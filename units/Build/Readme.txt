Hello, Thank you for downloading Weavver! :)

Intro: Weavver is a web-based personal/business management system designed to run as your public and internal operating platform.

Requirements:
  - IIS7 or Higher
  - .NET Framework 4 Platform Update 1
  - SQL Server 2005 with at least Service Pack 4

How to get started:

1. Place this folder somewhere on your system. There will be a directory tree:

    bin\
    www\

(C:\inetpub\weavver is usually a good spot)

2. Configure a virtual directory/website in IIS to point to the www folder. It should be configured as the root "/" and not as a sub-directory.

 - If you can't use the default website and this install will only be used locally try setting a fake name in your hosts file called "www.weavver.local" and using it to point to 127.0.0.1 as the domain name

3. Create an empty database in your database server called "WeavverDB" or some other name.

4. Copy www\web.default.config to www\web.config or compare files if this is an upgrade.

5. Configure your "appSettings" and "connectionStrings" in the web.config.

6. Surf to your Weavver install: Likely http://localhost

7. Test the connection and create your default settings/deploy the schema.

8. Create a scheduled task that runs "bin\WeavverConsole.exe --run-cron" periodically.

9. Turn off install_mode in your web.config file.

10. You're good to go!

We hope you enjoy and please make sure to drop us some feedback. It really helps motivate our team to hear from you!

Thank you,
Your friendly Weavver Team
 
 - "The mind is like a mythical box." - Pinky and the brain. -