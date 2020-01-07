using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CyberValetGrocery.Class
{
    public class AppConstants
    {
        /************ ADMIN SIDE ***********************/
        public const string strNoSaveListProd = "You currently do not have any saved shopping lists.";

        public const string strSaveListProdAlreadyExist = "Product already exist in this List";

        public const string strSaveListProdAdd = "Sucessfully Product added to List";

        public const string locationId = "1";

        public const string strYes = "Yes";

        public const string strNo = "No";

        public const string adminSorry = "Sorry, ";

        public const string noRecord = "No records found";

        public const string noProd = "No products found";

        public const string noTransaction = "No transaction records found";

        public const string imgError = "Only images are allowed";

        public const string savedListType = "1";

        // Forgot Email 

        public const string adminLength = "Length must be between 7 and ";

        public const string strAdminEmailAddress = "tejshri@maxnet-tech.com";

        public const string strForgotPasswordFileName = "ForgotPasswordEmail.txt";

        public const string strMailSubject = "New Password information ";

        public static string strFolderPath = "~//EmailContent";

        public static string strBackSlash = "//";

        public const string strUK = "UKPLUS";

        public const string StoreList = "Store Location";

        public const string invalidEmail = "Invalid email address";

        public const string invalidPhone = "Invalid  phone number";


        public const string loginFailed = "Your email address or password may have been entered incorrectly";

        public const string forgotPasswordSuccess = "Password sent to your email address";

        public const string forgotPasswordFailed = "Failed to send password  to your email address";

        public const string CompanyName = "BennettGrocery";

        //forgot password
        public const string noEmailExist = "Email address does not exist in our database";

        //Date
        public const string invalidToDate = "Invalid date, To Date should be smaller or equal to today's date";

        public const string invalidFromDate = "Invalid date, From Date should be smaller or equal to To date";


        // Aisle
        public const string asileAddSuccess = "Aisle added successfully";

        public const string asileAddFailed = "Failed to add aisle";

        public const string asileUpdateSuccess = "Aisle updated successfully";

        public const string asileUpdateFailed = "Failed to update aisle";


        public const string asileAlreadyExist = "Aisle name already exist";


        // Coupon
        public const string couponAddSuccess = "Promotional code added successfully";

        public const string couponAddFailed = "Failed to add promotional code";

        public const string couponAlreadyExist = "Promotional code already exist";

        public const string couponUpdateSuccess = "Promotional code updated successfully";

        public const string couponUpdateFailed = "Failed to update promotional code";

        public const string couponInvalid = "Invalid promotional code";

        public const string couponAlreadyUsed = "Promotional code has already been used";


        // Shelf

        public const string strSelectAisles = "Select  aisles";

        public const string shelfAddSuccess = "Shelf added successfully";

        public const string shelfAddFailed = "Failed to add shelf";

        public const string shelfUpdateSuccess = "Shelf updated successfully";

        public const string shelfUpdateFailed = "Failed to update shelf";

        public const string shelfAlreadyExist = "Shelf name already exist";


        // Aisle Top Aisle

        public const string AsileTopAisleAddSuccess = " Top aisle added successfully";

        public const string AsileTopAisleAddFailed = "Failed to add top aisle";

        public const string AsileTopAisleAlreadyExist = " Top aisle name already exist";

        public const string AsileTopUpdateSuccess = "Top aisle updated successfully";

        public const string strSelectTopAisles = "Select top aisles";


        // Zip

        public const string zipAddSuccess = "Zip Code added successfully";

        public const string zipAddFailed = "Failed to add zip code";

        public const string zipUpdateSuccess = "Zip Code updated successfully";

        public const string zipUpdateFailed = "Failed to update zip code";

        public const string zipAlreadyExists = "Zip code is already exists.";


        // Employee
        public const string strSelectPermission = "Select  permission(s)";

        public const string employeeAddSuccess = "Employee added successfully";

        public const string employeeAddFailed = "Failed to add employee code";

        public const string employeeUpdateSuccess = "Employee updated successfully";

        public const string employeeUpdateFailed = "Failed to update employee";

        public const string employeeEmailExist = "Email address already exist ";





        // User        

        public const string userUpdateSuccess = "User updated successfully";

        public const string userUpdateFailed = "Failed to update user";

        public const string userEmailExist = "Email already exist";


        // Newsletter
        public const string strNewsSuccess = "Email sent successfully to all users";

        public const string strBodyRequired = "Body is required";

        // Newsletter Sale
        public const string strNewsSaleSuccess = "Email sent successfully to all customers";


        public const string invalidNewsStartDate = "Invalid date,start date should be greater than today's date";

        public const string invalidNewsEndDate = "Invalid date, end date should be greater than start date";

        public const string invalidSDate = "Invalid date,start date should be in formate (mm/dd/yyyy)";

        public const string invalidEDate = "Invalid date,end date should be in formate (mm/dd/yyyy)";

        public const string invalidSEDate = "Invalid date,start & end  date should be in formate (mm/dd/yyyy)";



        //Newsletter Text

        public const string strNewsletterTextFile = "NewsletterText.txt";

        public const string strNewsletterSalesTextFile = "NewsletterSalesText.txt";

        public const int intUsersStatusId = 1;

        public const int intUsersNewsletter = 1;

        public const int intPreview = 1;


        //Transactions
        public const string tranAccountUpdateSuccess = "Account updated successfully";

        public const string tranAccountUpdateFailed = "Failed to update account";

        public const string strcommentRequired = "Comment is required";

        public const string tranFailed = "Transaction failed";



        // Product


        public const string productAddSuccess = "Product added successfully";

        public const string productAddFailed = "Failed to add product code";

        public const string productUpdateSuccess = "product updated successfully";

        public const string productUpdateFailed = "Failed to update product";


        public const string productAlreadyExist = "Product title with same size already exist";

        //sales

        public const string homeMessageSuccess = "Home page text set  successfully";

        public const string salesAddSuccess = "Sales item added successfully";

        public const string salesAddFailed = "Failed to add Sales item";


        // Shopping cart variables

        public const string customerServiceEmail = "Invalid customer service email";

        public const string contactEmail = "Invalid contact email";

        public const string infoEmail = "Invalid info email";

        public const string shoppingUpdateSuccess = "Shopping cart variables updated successfully";

        //Payment Options
        public const string paymentOptionSuccess = "Payment options updated successfully";

        public const string paymentOptionFailed = "Failed to update payment options";

        //product report

        public const string selectEndDate = "Select end date";

        public const string selectStartDate = "Select start date";

        public const string invalidProductReportStartDate = "Invalid date, start date should be smaller or equal to today's date";


        //Order Report


        public const string invalidOrderReportEndDate = "Invalid date,end date should be smaller or equal to today's date";

        public const string invalidOrderReportStartDate = "Invalid date, start date should be smaller or equal to end date";


        //order

        public const string orderType = "Select search by date type ordered or delivered";


        // Delivery Date
        public const string deliveryDateAddSuccess = "Delivery date added successfully";

        public const string deliveryDateAddFailed = "Failed to add delivery date";

        public const string invalidHours = "Select hours and enter it's respective #per slot";

        public const string invalidDate = "Invalid date,delivery date should be greater than today's date";

        public const string deliveryDateAlreadyExist = "Delivery date already exist";

        public const string deliveryDateZipCode = "Select zip code";

        //Delivery reminder
        public const string strDeliveryReminderTextFile = "deliveryReminder.txt";

        public const string strDeliveryRemindersuccessfully = "Reminder mail send successfully to all users";

        public const string strNoDeliveryReminder = "There are no orders places for selected delivery date";

        //Page Titles
        public const string shoppingCartConstant = " - Shopping Cart Variables";

        public const string addZipCode = " - Add Zip Code";

        public const string addTaxRate = " - Add Tax Rate";

        public const string addMinOrder = " - Add Minimum Order Amount";

        public const string updateZipCode = " - Update Zip Code";

        public const string updateTaxRate = " - Update Tax Rate";

        public const string updateMinOrder = " - Update Minimum Order";

        public const string displayZipCode = " - Zip Codes List";

        public const string displayMinOrd = " - Minimum Order List";

        public const string AddAisle = " - Add Aisle";

        public const string AddTodaysDate = " - Add In about an hour service ";

        public const string AddTopAisle = " - Add Top Aisle";

        public const string AddCoupon = " - Add Coupon";

        public const string AddEmployee = " - Add Employee";

        public const string AddProduct = " - Add Product";

        public const string AddShelves = " - Add Shelves";

        public const string AislesList = " - Aisles List";

        public const string DeliInfoList = " - Delivery Info List";

        public const string TopAislesList = " - Top Aisles List";

        public const string ShelvesList = " - Shelves List";

        public const string CouponCodeList = " - Coupon Code List";

        public const string CouponCodeReport = " - Coupon Code Report";

        public const string EmployeeList = " - Employee List";

        public const string TaxRateList = " - Tax Rate List";

        public const string NonDeliveryZones = " - Non-Delivery Zones";

        public const string Product = " - Product";

        public const string UpdateAisle = " - Update Aisle";

        public const string UpdateTopAisle = " - Update Top Aisle";

        public const string UpdateTodaysDelivery = " - Update In about an hour service";

        public const string UpdateCoupon = " - Update Coupon";

        public const string UpdateEmployee = " - Update Employee";

        public const string UpdateProduct = " - Update Product";

        public const string UpdateShelf = " - Update Shelf";

        public const string UpdateDeliveryInfo = " - Update Delivery Info";

        public const string ProductList = " - Product List";

        public const string CouponReportList = " - Coupon Report List";

        public const string DelieveryDateList = " - Delivery Date List";

        public const string TodaysDeliveryList = " - In about an hour service";

        public const string AddDelieveryDate = " - Add Delivery Date";

        public const string DelieveryDateTimeList = " - Delivery Time List";

        public const string SaleItems = " - Sale Items ";

        public const string SaleItemsList = " - Sale Items List";

        public const string AddSaleItems = " - Add Sale Items";

        public const string ProductReport = " - Product Report";

        public const string UserReport = " - User Report";

        public const string OrderReport = " - Order Report";

        public const string ProductReportList = " - Product Report List";

        public const string BalanceReport = " - Balance Report";

        public const string BalanceReportList = " - Balance Report List";

        public const string HomePage = " - Home";

        public const string LoginPage = " - Login";

        public const string User = " - User List";

        public const string Orders = "Orders";

        public const string UserUpdate = " - Update User ";

        public const string UserOrder = " - User Order List";

        public const string Depositors = " - User Depositors List";

        public const string paymentOptionTitle = " - Payment Option";

        public const string TransactionsList = " - Transactions List";

        public const string TransactionsUpdate = " - Credit or Debit An Account";

        public const string Newsletter = " - Newsletter (text) ";

        public const string SavedListReport = " - Saved List Report";

        public const string DeliverySchedules = " - Delivery Schedules";

        //Delivery Reminder
        public const string deliveryReminderPageTitle = " -  Delivery Reminders";

        public const string strOrderReminder = " - Order Reminder";

        public const string Newslettersales = " - Newsletter (sales)";

        public const string NewslettersalesHistory = "  - Newsletter(sales) History";

        public const string Addnewslettersales = " - Add Newsletter (sales)";

        public const string Editnewslettersales = " - Update Newsletter (sales)";

        //Shopping List

        public const string shoppingListPageTitle = " - Shopping List";

        public const string shoppingListPrintPageTitle = " - Shopping List Print";

        //Search Report
        public const string searchReportPageTitle = " - Search Reports";


        public const string unavailableSale = "Currently unavailable for sales";

        public const string NoProductavailableSale = "Currently no product is available for sales";









        /*********************** USER SIDE *************/

        //Page title
        public const string pgHowItWork = " - How It Works";
        public const string lolPrg = " - Loyalty Program ";

        public const string pgLoginPage = " - Login";

        public const string pgForgotpassword = " - Forgot password";

        public const string pgSuggestProduct = " - Suggest a Product";

        public const string pgContact = " - Contact Us";

        public const string pgShelf = " - shop Now - Shelves";

        public const string pgSignUp = " - Sign Up";

        public const string pgAccountFund = " - Shopping Funds";

        public const string pgMyAccount = " - My Account";

        public const string pgAboutCmp = " - About Us";
        public const string pgFAQs = " - Frequently Asked Questions ";

        public const string pgPrivacyPolicy = " - Privacy Policy";

        public const string pgTestimonials = " - Testimonials";

        public const string pgDeliveryInformation = " - Delivery Information";

        public const string pgReferFriend = " - Refer a Friend";

        public const string pgTermsConditions = " - Terms and Conditions";

        public const string pgSearchResult = " - Search Result";

        public const string pgShop = " - Shop Now - Aisles";

        public const string pgProduct = " - Shop Now - Product";

        public const string pgShopping = " - Shopping Cart";

        public const string pgSaveShopping = " - Save Shopping List";

        public const string pgMyShoppingList = " - My Shopping List";

        public const string pgConfirmDelivery = " - Shop Now - Confirm Delivery Address";

        public const string pgPickTime = " - Shop Now - Pick Your Delvery Time";

        public const string pgTip = " - Shop Now - Add a Tip";

        public const string pgPayment = " - Shop Now - Choose Your Payment Method";

        public const string pgOrdPrint = " - Confirm Order Print";

        public const string pgSales = "  - Shop Now - Sales!";

        public const string pgPastOrder = " - Past Order Details";

        public const string pgPastOrderNm = " - Past Orders";

        public const string pgIndex = " - Online Grocery Shopping and Delivery for";

        public const string pgComparePrice = " - Competitive Grocery Prices";


        public const string pgPayPalCancel = " - Paypal Cancel";


        //Email Subjects

        public const string strRegistrationMailSubject = "Registration Confirmation";

        public const string strRefferalMailSubject = "Check out";

        public const string strRefferalMailSubject1 = " - they deliver groceries to your door!";

        public const string strContactUsMailSubject = "Website Feedback Form";

        public const string strForgotPwdMailSubject = "Password Reminder";

        public const string strAccountFundParentMailSubject = "wants you to check out ";

        public const string strAccountFundParentMailSubject1 = " - online grocery shopping!";

        public const string strAccountFundUserMailSubject = "You Received a";

        public const string strAccountFundUserMailSubject1 = "Gift Certificate!";

        public const string strAccountFundUserParentMailSubject = "Funds deposit transfer successfully";

        public const string strSuggestProductMailSubject = " product suggestion";

        //User Login
        public const string userLoginFailed = "Your username or password may have been entered incorrectly";

        //User non delivery zone email
        public const string userEmailSendSuccuss = "Email sent successfully";

        public const string userEmailSendFailed = "Email send failed";

        public const string invalidUserEmail = "Invalid email";

        //Registration page

        public const string invalidUserRegEmail = "Invalid email address";

        public const string invalidUserRegPhone1 = "Invalid  primary phone number";

        public const string invalidUserRegPhone2 = "Invalid  secondary phone number";

        public const string userRegisterSuccuss = "You have sign up successfully";

        public const string userSelectAgree = "Please agree to terms and conditions";

        //User Forgot Password
        public const string userForgotPasswordSuccess = "An email with your password has been sent to you!";

        //User Update Login Info

        public const string userUpdateLoginInfoSuccuss = "Login Info updated successfully";

        public const string userUpdateLoginInfoFailed = "Fail to update login information";

        public const string UserRetypePassword = "Retype password is required";



        //User Update phone  Info

        public const string userUpdatePhoneInfoSuccuss = "Phone Info updated successfully";

        public const string userUpdatePhoneInfoFailed = "Fail to update phone information";

        //User Update Delivery Address  Info

        public const string userUpdateDeliveryAddressInfoSuccuss = "Delivery address Info updated successfully";

        public const string userUpdateDeliveryAddressInfoFailed = "Fail to update delivery address information";

        //User Update Billing Address  Info

        public const string userUpdateBillingAddressInfoSuccuss = "Billing address Info updated successfully";

        public const string userUpdateBillingAddressInfoFailed = "Fail to update billing address information";


        //User Contact us page

        public const string userContactEmailSuccuss = "Email sent successfully";

        public const string strUserContactEmailFileName = "UserContactUs.txt";

        public const string userContactEmailFailed = "Failed to send email";

        public const string strUserAccFundParentEmailFileName = "UserAccountFundParentEmail.txt";



        //User Suggest Product page

        public const string userSuggestProductSuccuss = "Suggested product added successfully";

        public const string strUserSuggestProductEmailFileName = "UserSuggestProduct.txt";

        //Account fund page

        public const string invalidRecipentEmail = "Invalid recipient email address";

        public const string invalidFundUserEmail = "Invalid your email";

        public const string userAccountFundSuccuss = "Funds added successfully";


        //Search result
        public const string pgSearchError = "Search keyword is required";




        //Product

        public const string pgNoDescription = "No Product Desciption Available";

        public const string GroceryMinimumOrder = "The groceries minimum order amount is";

        public const string DeliMinimumOrder = "The Buon Giorno Italian Market minimum order amount is";

        public const string RestaurantMinimumOrder = "The Restaurant minimum order amount is";

        public const string LiquorMinimumOrder = "The Liquor minimum order amount is";

        public const string GrocerySubTotalMinimumOrder = "The groceries(subtotal) minimum order amount is";

        public const string DeliSubTotalMinimumOrder = "The Buon Giorno Italian Market(subtotal) minimum order amount is";

        public const string RestaurantSubTotalMinimumOrder = "The Restaurant(subtotal) minimum order amount is";

        public const string LiquorSubTotalMinimumOrder = "The Liquor(subtotal) minimum order amount is";

        public const string pgOnlyNumber = "Quantity is a number.";

        public const string pgCartEmpty = "Your shopping cart is currently empty.";

        public const string pgSelectProdDel = "Please check the product you want to delete from shopping cart.";

        public const string pgCouponUsed = "The coupon code you entered is invalid or may have already been used";


        public const string selectDeliverytime = "Select delivery time";

        //sales

        public const string pgSalesErr = "There are currently no products listed for sale";

        public const string pgNoProduct = "Currently no shelf listed for this aisle";

        public const string NoShelfRecordFound = " There are currently no shelves listed under this aisle.";




        //order details
        public const string pgSelectProd = "Please check atleast one product from the list";



        // User Forgot Email 

        public const string strUserForgotPasswordFileName = "UserForgotPasswordEmail.txt";


        //refer a friend 

        public const string strUserReferAFriendFileName = "ReferralEmail.txt";

        public const string strReferEmailSuccuss1 = "Thank you";

        public const string strReferEmailSuccuss2 = "for referring your friend(s).";

        public const string strReferEmailSuccuss3 = "They have been sent an email from you inviting them to sign up for";

        //user

        public const string userEmailAlreadyExist = "Email address already exist";

        public const string strAccFundUserFileName = "UserAccountFundUserEmail.txt";

        public const string strAccFundUserParentFileName = "UserAccountFundUserParentEmail.txt";


        public const string strRegistrationFileName = "RegistrationText.txt";


        public const string invalidPhoneNumber = "Invalid phone";


        public const string invalidAccountFundAmt = "Deposit amount should be greater or equal to $";

        //My Account

        public const string strUserNoOrder = "You have no past orders.";

        public const string strNoBillAddress = "Currently no billing address available";

        public const string strAccountFundSuccuss = "Account funds transfered successfully";


        //Loyality Img

        public const string strLoyalityImg = "images/myaccount_reward";

        public const string strLoyalityImg1 = ".gif";

        public const string strLoyalityMsg = "You are ";

        public const string strLoyalityMsg1 = " orders away from $";

        public const string strLoyalityMsg2 = "of Account Funds!";



        //Saved List

        public const string strSaveListNmAlreadyExist = "List name already exist";

        public const string strSaveListFailed = "Failed to save shopping list";

        public const string strDeleteSaveListFailed = "Fail to delete saved shopping list";

        //Pick Time

        public const string strNoHours = "There are no hours for this day yet.";

        public const string strNoDelDateAva = "There are no delivery dates available";





        //order Payment type


        public const string strUserOrderConfirmFileName = "OrderConfirmation.txt";

        public const string strCOD = "COD";

        public const string strCODDetail = "CASH ON DELIVERY";


        public const string strCC = "CC";

        public const string strCCDetail = "CREDIT CARD CHARGE";



        public const string strAF = "AF";

        public const string strAFDetail = "WITHDRAWN FROM <br>ACCOUNT FUNDS";


        public const string strAFCOD = "AF-COD";

        public const string strAFCC = "AF-CC";


        public const string strOrderNm = "4444";


        public const string strTranNm = "100";







        public const string strLoyalOver = "$10 for reaching 5 orders over $100.";

        public const string strLoyalUnder = "$5 for reaching 5 orders under $100.";
















        // set API Credentials 
        public const string strAPIVersion = "2.3";

        public const string paymentmethod = "DoDirectPayment";

        public const string method = "POST";

        public const string strPaymentaction = "Sale";

        public const string strCountryCode = "US";

        public const string stripaddress = "192.168.1.117";

        public const string strErrorPaypalTransaction = "Please enter all the payment details properly.";
        //New Added

        public const string noClientRec = "No user registered for this zip";

        public const string noOrderRec = "No record found";


        public const string noClientActivityRec = "No user registered for date between ";

        public const string noClientActivityRec1 = "for zip";


        //live 
        public const string configfile = "1001329474";

        public const string host = "secure.linkpt.net";

        public const int port = 1129;

        public const bool fLog = true;

        //set logging level  
        // 0 - no logging
        // 1 - errors
        // 2 - debug ( errors + addl info )
        // 3 - trace ( full debug mode with call tracing )
        public const string logLvl = "2";





        // Tax Rates

        public const string TaxRateAddSuccess = "Tax rate added successfully";

        public const string TaxRateAddFailed = "Failed to add tax rate";

        public const string TaxRateUpdateSuccess = "Tax rate updated successfully";

        public const string TaxRateUpdateFailed = "Failed to update tax rate";

        public const string TaxRateAlreadyExists = "Tax rate is already exists.";


        // Minimum Order

        public const string MinOrderAddSuccess = "Minimum order added successfully";

        public const string MinOrderAddFailed = "Failed to add minimum order";

        public const string MinOrderAlreadyExists = "Minimum order is already exists.";

        public const string MinOrderUpdateSuccess = "Minimum order updated successfully";

        public const string MinOrderUpdateFailed = "Failed to update minimum order";

        // Time Info


        public const string TodayTimeAddSuccess = "Time added successfully";

        public const string TodayTimeAddFailed = "Failed to add Time";

        public const string TodayTimeAlreadyExist = "Time already exist";

        public const string TodayTimeUpdateSuccess = "Time updated successfully";

        public const string TodayTimeUpdateFailed = "Failed to update time";


        // User Pick time

        //public const string strNoTodaysDelivery = "There are no delivery times available, please try our ''in about an hour'' option";
        public const string strNoTodaysDelivery = "There are no delivery times available, please try our schedule a delivery for tomorrow";
        //

        public const string DeliveryInfoUpdateSuccess = "Delivery info updated successfully";

        public const string DeliveryInfoUpdateFailed = "Failed to update Delivery info";

        public const string DeliveryInfoAlreadyExist = "Delivery info already exist";

        public const string pgMinimumOrder = "The minimum order amount is";
        
        public const string pgMinimumOrderPayment = "The minimum order amount(Sub Total) is";


        public const string deliveryDatezipAlreadyExist = "Zipcode already exist!";
        public const string deliveryDateUdpateSuccess = "Delivery date updated successfully";
        public const string invalidTime = "Select hours or blank it's respective #per slot";        
    }
}
