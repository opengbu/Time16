import requests
url = 'http://gbuonline.in/timetable/uploaddb.php'
print("Uploading data.")
files = {'file': open('d:\\Timetables2014\\varun.db', 'rb')}
r = requests.post(url, files=files)            
