fromAddress = 'sender@example.com'
toAddress = 'me@my.domain'
msg = 'Subject: Hello, this is the body of the message'
import smtplib
server = smtplib.SMTP("localhost", 25)
server.sendmail(fromAddress, toAddress, msg)
