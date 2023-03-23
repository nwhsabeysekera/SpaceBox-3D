# SpaceBox-3D

This tool is designed to enable blind people to touch and feel drawings using a newly constructed 3D printer. The tool consists of a client application that allows users to select standard shapes from a drop down list or enter text to be converted to Braille. The server-side component is a computation service that provides the required dot amount or liquid amount based on the selected shape or Braille text.



Features

  •	Select standard shapes from a drop-down list (circle, triangle, and rectangle)
 
  •	Enter Braille text to be converted into dots
  
  •	Get the list of parameters related to a shape (e.g. radius and center for a circle) and compute the perimeter to determine the required dot amount
  
  •	Count the number of dots for Braille text to compute the required liquid amount
  
  •	Access the service via HTTP/SOAP
  
  •	Retrieve the list of supported shapes and Braille characters from the service
  
  • Use best practices and design patterns for the implementation
  
  • Implement using .NET framework



Usage

   The Braille Printer Service provides a drop-down list of supported shapes, including circle, triangle, and rectangle, as well as a list of supported Braille 
   characters. The client tool allows the user to select a shape or Braille character, and request the required parameters from the service.
  
   When a standard shape is selected, the service will retrieve the list of parameters related to the shape, such as the radius and center for a circle, and compute 
   the perimeter so that the required dot amount can be determined. When a Braille character is selected, the service will count the number of dots required to compute 
   the required liquid.
  
   The client tool provides a form where the user can provide values for the requested parameters, and the service will perform the computation and send the results 
   back to the client application.



Technologies Used

    • .NET Framework for development
  
    • HTTP/SOAP for communication between the client and service
   
    • Design patterns for best practices
 
 
View the figma design from this link (view only) -  https://www.figma.com/file/8b3ZQ5WCncqY1gkHcyITbn/3D-Printer?node-id=0%3A1&t=Tuy6caKlXYyGkgdy-1
