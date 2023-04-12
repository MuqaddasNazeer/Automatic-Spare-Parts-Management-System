<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="homepage.aspx.cs" Inherits="FinalProject.homepage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <section>
       <img src="images/home1.jpg" class="image-fluid" width="100%/9" height="500"/>
   </section>
   <section>
      <div class="container">
         <div class="row">
            <div class="col-12">
               <center>
                  <h2>Our Features</h2>
                  <p><b>Primary Features -</b></p>
               </center>
            </div>
         </div>
         <div class="row">
            <div class="col-md-3">
               <center>
                   <img width="200px" src="images/sparePart.png" />
                  <h4>Spare Parts</h4>
                  <p class="text-justify">The Spare-Part Module is a key component of system that provides these sub modules: 
                                            •Adding new spare parts 
                                            •Defining category and dimensions 
                                            •Editing details of spare parts 
                                            •Product Catalog 
                                            •Product Pricing and Inventory 
                   </p>
               </center>
            </div>
            <div class="col-md-3">
               <center>
                   <img width="200px" src="images/manufacturer.jpg" />
                  <h4>Manufacturer</h4>
                  <p class="text-justify">The Manufacturers Module will provide interfaces for managing manufacturers including: 
                                •Adding new manufacturers to the system 
                                •Editing details of manufacturers 
                                •Managing contact details and products offered 
                                •Viewing a list of all manufacturers and their products 
                                •Tracking performance 
                                •Managing Trust Factors 
                                •Managing Trust Factors Weightages for a Shipment 
                   </p>
               </center>
            </div>
             <div class="col-md-3">
               <center>
                   <img width="200px" src="images/order.png" />
                   
                  <h4>Order Management</h4>
                  <p class="text-justify">The Orders Management module enables users to create and edit customer orders, track their status, and view order history. It allows the admin to monitor order progress, link gate passes to orders, and post orders to accounts. This module is crucial for ensuring timely order fulfillment and enables the admin to make decisions regarding products if any issues arise like late order or canceled order. </p>
               </center>
            </div>
            <div class="col-md-3">
               <center>
                   <img width="200px"  src="images/accounting.png" />
                  <h4>Account And Billing Management</h4>
                  <p class="text-justify">The Accounts and Billing Management module provides interfaces for creating new accounts. managing transactions, posting bills for orders, allows the admin to track overdue payments, and they can also generate balance sheet. The module provides a detailed overview of all financial activities. </p>
               </center>
            </div>
            <div class="col-md-3">
               <center>
                   <img width="200px" src="images/packing.jpg" />
                  <h4>Packing Management</h4>
                  <p class="text-justify">The Packing Management module deals with the packing process of spare parts before they are shipped. It allows the User to create and manage packing lists, as well as track the status of packing. The admin can easily monitor the quantity of products packed, the date and time of packing, and other relevant details. This information can then be used to make informed decisions about scheduling shipments and allocating warehouse storage. </p>
               </center>
            </div> 
             <div class="col-md-3">
               <center>
                   <img width="230px" src="images/shipping.png" />
                  <h4>Shipping Management</h4>
                  <p class="text-justify">The shipment module will maintain a record of all the shipments that have been made and their corresponding shipment numbers, container numbers, vehicle numbers, packing lists, and dates. The shipment module will also ensure that the packing lists are updated to remove some entries due to export limits, weight, and volume restrictions, as required on the day of shipment</p>
               </center>
            </div> 
            <div class="col-md-3">
               <center>
                   <img width="150px" src="images/reporting.jpg" />
                  <h4>Reporting and Listing</h4>
                  <p class="text-justify">This module will able to generate, view, print and save all the lists and reports to be generated in system under discussion in pdf format. The Reports and Lists Management module is a critical tool for Admin to monitor the system's performance and make data-driven decisions based on the available data. These features collectively provide an end-to-end solution for spare parts management, from adding new spare parts to shipping them to customers, with tools to manage manufacturers, orders, accounts, and packing. The system also provides a comprehensive set of reports and lists that enable users to monitor performance and make data-driven decisions	</p>
               </center>
            </div> 
         </div>
      </div>
   </section>
   <section>
      <img src="images/store.jpg" class="img-fluid" width="100%/9" height="50"/>
   </section>
   <section>
      <div class="container">
         <div class="row">
            <div class="col-12">
               <center>
                  <h2>Our Process</h2>
                  <p><b>We have a Simple 3 Step Process</b></p>
               </center>
            </div>
         </div>
         <div class="row">
            <div class="col-md-4">
               <center>
                  <img width="100px"  src="images/signup.jpg" />
                  <h4>Sign Up</h4>
                  <p class="text-justify">Click Here to SIgn UP</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                  <img width="200px" src="images/manufacturer.jpg" />
                  <h4>Search Manufacturer </h4>
                  <p class="text-justify">Serach manufacturer on basis of their Id's</p>
               </center>
            </div>
            <div class="col-md-4">
               <center>
                  <img width="150px" src="images/visit.jpg" />
                  <h4>Visit Us</h4>
                  <p class="text-justify">Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Lorem ipsum dolor. reprehenderit</p>
               </center>
            </div>
         </div>
      </div>
   </section>
</asp:Content>