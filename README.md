# LawProject
Law project is a Interactive Law Firm Automation and Management System. People in the field of law will benefit from this application.  This project was developed using N-Layer Architecture and AOP.

</br></br> 

### Project Document
[embed]https://github.com/RamazanHalid/LawProject/files/8835367/Senior.Project.Medilaw.Ramazan.Halid.-.Samin.Taheri.pdf[/embed]

MediLaw Admin:
•	Register page:
The Register page was the first page created in this application. Users must enter information such as their name, title, cellphone, email, country, city, and password on this page. All this information is validated using “yup,” a JavaScript schema builder for value parsing and validation. The city option in the register form is displayed according to the selection of the country. After the user enters all this information and presses the “Sign Up!” button, it first performs a validation control of the password and confirm password equality. In case any error occurs, an error popup that has been imported and integrated as a component will appear and display the error to the users. If there are no problems, a loader will be displayed in the button to show the users the improvements of the process. Once completed, as shown in the second figure, a success pop up will appear to show the users that the process was successful, and the user will be registered to the system and directed to the login page. There is also an option on the top right corner of the page to redirect the users to the login page in case they already have an account.
The user interface of this page is depicted in the first image.
 
Figure 1:
 image.png
Figure 2:
•	Login, Approve Account pages:
After user registers to the system, he/she will be directed to the login page where he/she will confirm his/her account since it is the first time the user will use the system. First as shown in the third figure, once the user enters his/her cellphone number and password and presses the login button, an approvement code will be sent via SMS to confirm his/her account. In the next step, as shown in the fourth figure, the user will be directed to the account approvement page and once they enter their phone number along with the approvement code sent to their cellphone number, as shown in the fifth figure a success pop up will appear which shows that they have been approved their account successfully. In the next step the users will be directed to the login page again to approve their email this time. After they enter their cellphone which has been approved along with their password, a pop up will appear that says they should approve their email address as well. In this step, the users would have to check their email inboxes and they will be able to approve their email address by clicking on the email sent from MediLaw. In this step which the user has been approved his/her cellphone number and email account, he/she will be able to successfully login to the system. After the user enters the cellphone number and password and clicks the “login” button a loader will be displayed in the button to show the users the improvements of the process and after that, a success pop up will appear to show the users they have been logged in to the system successfully.
 
Figure 3:

