<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebApplication3._Default" %>
 
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">

        <h3>LibreWorx Hugh Jones 2- Year Notes</h3>
        <a href="https://docs.google.com/a/libreworx.com/document/d/1LoA2GJmq14rEYMDCNHVd1hCaGJnDY2Ux_a2KyW7F38g/edit?usp=sharing">My 2-year plan.</a>


        <h3>Problem 1: Best of Three</h3><p id="1"></p>
        <h3>Problem 2: Sum Times</h3><p id="2"></p>
        <h3>Problem 3: Factoral or Fiction</h3><p id="3"></p>
        <h3>Problem 4: The Palindrome</h3><p id="4"></p>
        <h3>Problem 5: Buzz Fizz, oooolala</h3><p id="5"></p>
        <h3>Problem 6: Perfect Fit</h3><p id="6"></p>
        <h3>Problem 7: Be Happy</h3><a href="http://jonesh-mvchappy.azurewebsites.net/Home/HappyNumbers?num=8">Be Happy Solution</a>
        <h3>Problem 8: Is Your Arm Strong?</h3><p id="8"></p>

        
        
 
    <script language="JavaScript" type="text/javascript">

        var points = [40, 100, 1];

        function mySortFunction(a,b,c) {
            return Math.max(a,b,c);
        };

        document.getElementById("1").innerHTML = mySortFunction(points[0],points[1],points[2]);


            function mySumFunction(numbers) {
                var total = 0;
            
                for (var i = 0; i < numbers.length; i++) {
                    total += numbers[i];
                
                }
                return total;
                }

            document.getElementById("2").innerHTML = mySumFunction([1, 23, 4]);

            function myMultiplyFunction(numbers) {
                var total = 1;

                for (var i = 0; i < numbers.length; i++) {
                    total = total * numbers[i];

                }
                return total;
            }

            document.getElementById("2").innerHTML = document.getElementById("2").innerHTML + ",\ " + myMultiplyFunction([1, 23, 4]);
           
        
        //NUMBER 3
        //Factorial

            function myFictionFunction(number) {
                var total = 1;
                for (var i = number; i > 0; i--) {
                    total = total * i;
                }
                return total;
            }

            document.getElementById("3").innerHTML = myFictionFunction(4);
        
            //NUMBER 4
            
            function myPalindromeFunction(string1) {
                    
                    var string2 = "";

                    for (var i = string1.length-1; i >= 0; i--) {
                        string2 += string1.charAt(i);
                    }

                    if (string1 == string2) {
                        pala = "yes";
                    } else {
                        pala = "no";
                    }

                return pala;
            }

            document.getElementById("4").innerHTML = myPalindromeFunction("PILIssdfP");

            //NUMBER 5

            function myBuzzFunction() {



                //begin with 1
                var collector = "";
                //Rotate Up to 100
                for (var i = 1; i <= 100; i++) {
                    var str = "";
                    //compare 3 = Fizz          
                    if (i % 3 === 0) {
                        //Fizz
                        str += "Fizz";
                    }
                    if (i % 5 === 0) {
                        //Buzz if / 5
                        str += "Buzz";
                    }
                    else if (str === "") {
                        str += i;
                    }
                    collector += str + "<br>";
  
                }

                return collector;
            }

            document.getElementById("5").innerHTML = myBuzzFunction();
        

        ///////////////////////////////////////////////////////////////////////////////////

        //NUMBER 6

        document.getElementById("6").innerHTML = checkingNumber();

        function checkingNumber() {
            perfectNumberString = "";
                for (i = 1; i <= 10000; i++) {
                    //calculate divisors for each number
                    store = 0;
                    for (p = 1; p <= i; p++) {
                        if (i % p === 0) {
                            //sum divisors
                            store += p;
                            if (store === i) {
                                perfectNumberString += i + "<br>";
                            }
                        }
                        
                    }
                    
                }
                return perfectNumberString;
            }

        //Math.sqrt(i)

            ///////////////////////////////////////////////////////////////////////////////////
        //NUMBER 7 HAPPY

        //document.getElementById("7").innerHTML = myHappyFunction();
       

        //function myHappyFunction() {
            

     
          //  myHappyNumber = "Cannot do Yet";
          //  return myHappyNumber;
      //  }

            
        
            ///////////////////////////////////////////////////////////////////////////////////
        //NUMBER ARMSTRONG

            document.getElementById("8").innerHTML = myArmstrongFunction();

            function myArmstrongFunction() {
                armStrongNumber = "";
                var z, b, c = 0;
                //test numbers from 1 to 10000
                for (var i = 100; i <= 999; i++) {
                    z = i;
                    c = 0;
                    while (z > 0)
                    {
                        b = z % 10;
                        c = c + (b * b * b);
                        z = parseInt(z / 10);
                    }
                    if (i == c) {
                        armStrongNumber += i + "<br>";
                    }
                   
                }
                return armStrongNumber;
            }

        </script>
    </div>


   

</asp:Content>
