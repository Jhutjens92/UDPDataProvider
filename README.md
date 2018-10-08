# WEKIT UDPDataProvider
The WEKIT UDPDataProvider is an application designed to act as a UDP server, receive the data, send data back to a specific ipaddress for the VTTPlayer and send the data to the Learning Hub.

### Prerequisites
- Download the Learning Hub: https://github.com/janschneiderou/LearningHub

## Getting Started
Default settings:
ServerPort = 5005;
ClientPort = 5006;
ClientAddress = "0.0.0.0"

You can test the UDPDataProvider without using the Learning Hub by just starting the executable and press "Start Recording"
Currently it does not provide any logging when you run it seperatly. It only shows the received string in the textbox for testing.

If you want to use it with the Learning Hub combined then make you sure have the Learning Hub set up accordingly. 
A complete how to guide can be found here: https://docs.google.com/document/d/1FbTd6wjqa9P_6O51gjZRU2ubiCA94nMZr001NkgBZ5s/edit#

## Startup Parameters (Learning Hub)
-sp *port number* (example -sp 3300) 
-cp *port number* (example -cp 3300) 
-sa *serveraddress* (example -sa 192.168.0.1) 

## Running the tests
For testing purposes you can use this test string: 
{"client":"WEKIT-VEST-000014A2","time":992953,"imus":[{"ax":-0.04,"ay":1.25,"az":-0.06,"gx":-7.33,"gy":-171.49,"gz":-7.33,"mx":-14.29,"my":5.39,"mz":-3.46,"q0":-0.26,"q1":-0.40,"q2":0.57,"q3":0.67},{"ax":-0.05,"ay":1.23,"az":-0.34,"gx":-7.43,"gy":-171.434,"gz":-7.34,"mx":-14.39,"my":5.39,"mz":-3.36,"q0":-0.36,"q1":-0.30,"q2":0.37,"q3":0.63}],"shts":[{"temp":33,"hum":80},{"temp":21,"hum":55}],"pulse":60,"gsr":1024}

## Authors
* **Jordi Hutjens** -(https://github.com/jhutjens92)