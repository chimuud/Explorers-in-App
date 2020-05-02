using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//using System.IO;
//using System.Reflection;
//using System.Runtime.InteropServices;
//using System.Windows.Forms;
//using System.Configuration;

namespace QA_Tools
{
    class clsRecordDetails
    {
        int FStartPos;
        int FLength;
        string FDataType;
        string FRequirement;

        public int StartPos
        {
            get { return FStartPos; }
            set { FStartPos = value; }
        }
        public int Length
        {
            get { return FLength; }
            set { FLength = value; }
        }
        public string DataType
        {
            get { return FDataType; }
            set { FDataType = value; }
        }
        public string Requirement
        {
            get { return FRequirement; }
            set { FRequirement = value; }
        }
    }
    class clsORecord
    {
        public string Record_Type { get; set; }
        public string Record_Sub_Type { get; set; }
        public string Primary_SSN { get; set; }
        public string Secondary_Mailing_Address { get; set; }
        public string Secondary_Mailing_City { get; set; }
        public string Secondary_Mailing_State { get; set; }
        public string Secondary_Mailing_Zip_Code { get; set; }
        public string Primary_Physical_Address { get; set; }
        public string Primary_Physical_City { get; set; }
        public string Primary_Physical_State { get; set; }
        public string Primary_Physical_Zip_Code { get; set; }
        public string Secondary_Physical_Address { get; set; }
        public string Secondary_Physical_City { get; set; }
        public string Secondary_Physical_State { get; set; }
        public string Secondary_Physical_Zip_Code { get; set; }
        public string Primary_ID_Description { get; set; }
        public string Primary_ID_Number { get; set; }
        public string Secondary_ID_Description { get; set; }
        public string ID_Number { get; set; }
        public string State_Filed_1 { get; set; }
        public string State_Refund_Amount_1 { get; set; }
        public string State_Filed_2 { get; set; }
        public string State_Refund_Amount_2 { get; set; }
        public string State_Filed_3 { get; set; }
        public string State_Refund_Amount_3 { get; set; }
        public string RTN_From_1040 { get; set; }
        public string EFIN { get; set; }
        public string Filler1 { get; set; }
        public string Transmitter_GUID { get; set; }
        public string Issuing_Authority_1 { get; set; }
        public string Issue_Date_1 { get; set; }
        public string Expiration_Date_1 { get; set; }
        public string Issuing_Authority_2 { get; set; }
        public string Issuing_Date_2 { get; set; }
        public string Expiration_Date_2 { get; set; }
        public string Taxpayer_Citizenship { get; set; }
        public string Taxpayer_Country_of_Citizenship { get; set; }
        public string Citizenship { get; set; }
        public string Spouse_Country_of_Citizenship { get; set; }
        public string DAN_From_1040 { get; set; }
        public string Filler2 { get; set; }
    }
    class clsRRecord
    {
        public string Record_Type { get; set; }
        public string Record_Sub_Type { get; set; }
        public string Primary_SSN { get; set; }
        public string Secondary_SSN { get; set; }
        public string Master_EFIN { get; set; }
        public string EFIN { get; set; }
        public string Office_IDENT { get; set; }
        public string Filing_Status { get; set; }
        public string Primary_First_Name { get; set; }
        public string Primary_Middle_Initial { get; set; }
        public string Primary_Last_Name { get; set; }
        public string Secondary_First_Name { get; set; }
        public string Secondary_Middle_Initial { get; set; }
        public string Secondary_Last_Name { get; set; }
        public string Primary_Mailing_Address { get; set; }
        public string Primary_Mailing_City { get; set; }
        public string Primary_Mailing_State { get; set; }
        public string Primary_Mailing_Zip_Code { get; set; }
        public string Home_Telephone_Number { get; set; }
        public string Work_Telephone_Number { get; set; }
        public string State_Refund_Amount { get; set; }
        public string State_Filed { get; set; }
        public string IRS_ACK_Date { get; set; }
        public string Debt_Indicator { get; set; }
        public string ACK_Refund_Amount { get; set; }
        public string Transmitter_EF_Fee { get; set; }
        public string Master_EFIN_EF_Fee { get; set; }
        public string Site_EF_Fee { get; set; }
        public string Site_PREP_Fee { get; set; }
        public string Site_RT_Fee { get; set; }
        public string POS_Fees_1 { get; set; }
        public string POS_Fees_2 { get; set; }
        public string POS_Fees_3 { get; set; }
        public string Cell_Phone_Number { get; set; }
        public string SMS_Opt_In { get; set; }
        public string TPEmailMarketConsent { get; set; }
        public string Disbursement_Method { get; set; }
        public string TP_RTN { get; set; }
        public string TP_DAN { get; set; }
        public string TP_ACCT_Type { get; set; }
        public string Instant_Issue_ID { get; set; }
        public string Advance_Only_Indicator { get; set; }
        public string Internal_Use_1 { get; set; }
        public string Internal_Use_2 { get; set; }
        public string EIC_Amount { get; set; }
        public string Taxpayer_E_Mail_Address { get; set; }
        public string Number_Times_Return_Transmitted { get; set; }
        public string Primary_Date_of_Birth { get; set; }
        public string TPG_Internal_Use_B { get; set; }
        public string Filler1 { get; set; }
        public string POS_Product_Code_1 { get; set; }
        public string POS_Product_Code_2 { get; set; }
        public string POS_Product_Code_3 { get; set; }
        public string Transmitter_GUID { get; set; }
        public string Spouse_Date_of_Birth { get; set; }
        public string ERO_State_Location_Special_Handling_Indicator { get; set; }
        public string Filler2 { get; set; }
        public string Deceased_Indicator { get; set; }
        public string State_Tax_on_Product { get; set; }
        public string State_Tax_on_POS_Sales { get; set; }
        public string TPG_Internal_Use_D { get; set; }
        public string History_Indicator { get; set; }
        public string State_Only_Indicator { get; set; }
        public string IRS_Acceptance_Code { get; set; }
        public string Reg_B_Opt_Out { get; set; }
        public string FCA_Applicant { get; set; }
        public string Communication_Preference { get; set; }
        public string Due_Diligence_Indicator { get; set; }
        public string Checkless_Indicator { get; set; }
    }
    class clsTRecord
    {
        public string Record_Type { get; set; }
        public string Record_Sub_Type { get; set; }
        public string Filler1 { get; set; }
        public string Transmitter_Name { get; set; }
        public string Batch_DateTime { get; set; }
        public string Batch_IDENT { get; set; }
        public string Total_Record_Count { get; set; }
        public string Total_Record_Amount { get; set; }
        public string X_Record_Count { get; set; }
        public string R_Record_Count { get; set; }
        public string R_Record_Amount { get; set; }
        public string A_Record_Count { get; set; }
        public string A_Record_Amount { get; set; }
        public string U_Record_Count { get; set; }
        public string U_Record_Amount { get; set; }
        public string P_Record_Count { get; set; }
        public string P_Record_Amount { get; set; }
        public string S_Record_Count { get; set; }
        public string S_Record_Amount { get; set; }
        public string C_Record_Count { get; set; }
        public string C_Record_Amount { get; set; }
        public string F_Record_Count { get; set; }
        public string F_Record_Amount { get; set; }
        public string V_Record_Count { get; set; }
        public string V_Record_Amount { get; set; }
        public string G_Record_Count { get; set; }
        public string Z_Record_Count { get; set; }
        public string B_Record_Count { get; set; }
        public string D_Record_Count { get; set; }
        public string O_Record_Count { get; set; }
        public string TPG_Internal_Use_B { get; set; }
        public string R2_Record_Count { get; set; }
        public string R2_Record_Amount { get; set; }
        public string Filler2 { get; set; }

    }
    class clsURecord
    {
        public string Record_Type { get; set; }
        public string Record_Sub_Type { get; set; }
        public string Primary_SSN { get; set; }
        public string Secondary_SSN { get; set; }
        public string Master_EFIN { get; set; }
        public string EFIN { get; set; }
        public string Office_IDENT { get; set; }
        public string ACK_Refund_Amount { get; set; }
        public string Amount_Paid_Directly_to_You { get; set; }
        public string Fees_Paid_to_ERO { get; set; }
        public string TPG_Internal_Use_E1 { get; set; }
        public string TPG_Internal_Use_E2 { get; set; }
        public string Amount_Paid_to_TPG { get; set; }
        public string Amount_Previously_Paid { get; set; }
        public string Total_Loan_Amount { get; set; }
        public string Estimated_Annual_Percentage_Rate { get; set; }
        public string DISB_Number { get; set; }
        public string Debt_Paid_To_Cross_Collection { get; set; }
        public string Total_Federal_Deposit { get; set; }
        public string Total_State_Deposit { get; set; }
        public string Check_Reissue_Flag { get; set; }
        public string Total_Preparer_Debt_Disb_Amount { get; set; }
        public string Site_RT_Fee { get; set; }
        public string Total_Other_Debt_Disb_Amount { get; set; }
        public string Filler { get; set; }
        public string Original_Product_Code { get; set; }
        public string State_Tax_on_Product { get; set; }
        public string State_Tax_on_POS_Sales { get; set; }
        public string Fees_Paid_to_Transmitter { get; set; }
        public string Debt_Paid_To_Debtor_Bank_Name { get; set; }
        public string Z_Record_Not_Set_Up_Indicator { get; set; }
        public string Adjustment_Indicator { get; set; }
        public string State_of_Adjustment { get; set; }
        public string Primary_Last_Name { get; set; }
        public string Account_Handling_Fee { get; set; }
        public string Disbursement_Fee { get; set; }
        public string Deceased_Indicator { get; set; }
        public string State_Bank_Fee { get; set; }
        public string Special_Fee_1_Type { get; set; }
        public string Special_Fee_1_Amount { get; set; }
        public string Special_Fee_2_Type { get; set; }
        public string Special_Fee_2_Amount { get; set; }
        public string Special_Fee_3_Type { get; set; }
        public string Special_Fee_3_Amount { get; set; }
        public string Filler1 { get; set; }
        public string Transmitter_GUID { get; set; }
        public string Fees_Paid_to_Service_Bureau { get; set; }
        public string POS_Amount { get; set; }
        public string Bank_Indicator { get; set; }
        public string TPG_Internal_Use_E3 { get; set; }
        public string TPG_Internal_Use_E4 { get; set; }
        public string TPG_Internal_Use_E5 { get; set; }
        public string TPG_Internal_Use_E6 { get; set; }
        public string TPG_Internal_Use_H1 { get; set; }
        public string TPG_Internal_Use_H2 { get; set; }
        public string TPG_Internal_Use_H3 { get; set; }
        public string TPG_Internal_Use_H4 { get; set; }
        public string TPG_Internal_Use_H5 { get; set; }
        public string TPG_Internal_Use_H6 { get; set; }
        public string TPG_Internal_Use_H7 { get; set; }
        public string TPG_Internal_Use_H8 { get; set; }
        public string TPG_Internal_Use_H9 { get; set; }
        public string TPG_Internal_Use_H10 { get; set; }
        public string TPG_Internal_Use_E7 { get; set; }
        public string Advance_Plus_Interest { get; set; }
        public string Master_Advance_Paid { get; set; }
        public string Filler2 { get; set; }
    }
    class clsPRecord
    {
        public string Record_Type { get; set; }
        public string Record_Sub_Type { get; set; }
        public string Primary_SSN { get; set; }
        public string Secondary_SSN { get; set; }
        public string Master_EFIN { get; set; }
        public string EFIN { get; set; }
        public string Office_IDENT { get; set; }
        public string DISB_Number { get; set; }
        public string SPC_DISB_Amount { get; set; }
        public string SPC_SEQ_Number { get; set; }
        public string SPC_DISB_Date { get; set; }
        public string PREV_SPC_SEQ_Number { get; set; }
        public string TPG_Internal_Use_E1 { get; set; }
        public string TPG_Internal_Use_E2 { get; set; }
        public string Filler { get; set; }
    }
    class clsARecord
    {
        public string Record_Type { get; set; }
        public string Record_Sub_Type { get; set; }
        public string Primary_SSN { get; set; }
        public string Secondary_SSN { get; set; }
        public string Master_EFIN { get; set; }
        public string EFIN { get; set; }
        public string Office_IDENT { get; set; }
        public string ACK_Refund_Amount { get; set; }
        public string DISB_Number { get; set; }
        public string Bank_Printed_Check { get; set; }
        public string BPC_DISB_Amount { get; set; }
        public string BPC_SEQ_Number { get; set; }
        public string BPC_DISB_Date { get; set; }
        public string BPC_STOP_Date { get; set; }
        public string Site_Printed_Check { get; set; }
        public string SPC_DISB_Amount { get; set; }
        public string SPC_SEQ_Number { get; set; }
        public string SPC_DISB_Date { get; set; }
        public string SPC_STOP_Date { get; set; }
        public string Direct_Deposit { get; set; }
        public string DD_DISB_Amount { get; set; }
        public string DD_DISB_Date { get; set; }
        public string DD_RET_Date { get; set; }
        public string DD_RTN { get; set; }
        public string DD_DAN { get; set; }
        public string DD_Account_Type { get; set; }
        public string Bank_Indicator { get; set; }
        public string Fee_Intercept_Collected_Amount { get; set; }
        public string Fee_Intercept_To_Collect_Amount { get; set; }
        public string Master_Advance_Paid { get; set; }
        public string Advance_Plus_Interest { get; set; }
        public string Bank_Transfer { get; set; }
        public string BT_DISB_Amount { get; set; }
        public string BT_DISB_Date { get; set; }
        public string BT_RET_Date { get; set; }
        public string Cash_Card { get; set; }
        public string CC_DISB_Amount { get; set; }
        public string CC_DISB_Date { get; set; }
        public string CC_RET_Date { get; set; }
        public string CC_Number { get; set; }
        public string Disbursement_Fee { get; set; }
        public string BAL_Due_Minus_Base_Bank_Fee { get; set; }
        public string Total_XCOL_Debt_Disb_Amount { get; set; }
        public string Debt_Disbursement_Indicator { get; set; }
        public string Balance_Due_To_Taxpayer { get; set; }
        public string Product_Indicator { get; set; }
        public string Total_Preparer_Debt_Disb_Amount { get; set; }
        public string TPG_Internal_Use_E { get; set; }
        public string Total_Other_Debt_Disb_Amount { get; set; }
        public string Held_Disbursement { get; set; }
        public string Cancel_Date { get; set; }
        public string IRS_Funded_Amount { get; set; }
        public string State_Funded_Amount { get; set; }
        public string Adjustment_Indicator { get; set; }
        public string Transmitter_Fee_Disb_Total { get; set; }
        public string Master_EFIN_Fee_Disb_Total { get; set; }
        public string Site_Fee_Disb_Total { get; set; }
        public string State_of_Adjustment { get; set; }
        public string TPG_Internal_Use_E1 { get; set; }
        public string TPG_Internal_Use_E2 { get; set; }
        public string Prepaid_Finance_Charge { get; set; }
        public string APR { get; set; }
        public string Bank_Fee { get; set; }
        public string Primary_Last_Name { get; set; }
        public string Account_Handling_Fee { get; set; }
        public string Amount_Previously_Paid { get; set; }
        public string Deceased_Indicator { get; set; }
        public string Transmitter_GUID { get; set; }
        public string State_Bank_Fee { get; set; }
        public string Fee_Advance_Indicator { get; set; }
        public string Total_POS_Fees { get; set; }
        public string Internal_Use_E { get; set; }
        public string Filler { get; set; }
    }
    class clsFRecord
    {
        public string Record_Type { get; set; }
        public string Record_Sub_Type { get; set; }
        public string Primary_SSN { get; set; }
        public string Secondary_SSN { get; set; }
        public string Master_EFIN { get; set; }
        public string EFIN { get; set; }
        public string Office_IDENT { get; set; }
        public string Fees_DISB_Date { get; set; }
        public string Transmitter_Fee_Disbursed { get; set; }
        public string Master_EFIN_Fee_Disbursed { get; set; }
        public string Site_Fee_Disbursed { get; set; }
        public string Transmitter_Fee_Disb_Total { get; set; }
        public string Master_EFIN_Fee_Disb_Total { get; set; }
        public string Site_Fee_Disb_Total { get; set; }
        public string Transmitter_Inct_Fee { get; set; }
        public string Master_EFIN_Inct_Fee { get; set; }
        public string Site_Inct_Fee { get; set; }
        public string Transmitter_EF_Fee { get; set; }
        public string Master_EFIN_EF_Fee { get; set; }
        public string Site_EF_Fee { get; set; }
        public string Site_PREP_Fee { get; set; }
        public string Site_RT_Fee { get; set; }
        public string Bank_Fee { get; set; }
        public string State_Bank_Fee { get; set; }
        public string Fees_Changed_Indicator { get; set; }
        public string State_Funding_Indicator { get; set; }
        public string Federal_Funding_Indicator { get; set; }
        public string POS_Fees_1 { get; set; }
        public string POS_Fees_2 { get; set; }
        public string POS_Fees_3 { get; set; }
        public string Filler { get; set; }
        public string Product_Indicator { get; set; }
        public string POS_Product_Code_1 { get; set; }
        public string POS_Product_Code_2 { get; set; }
        public string POS_Product_Code_3 { get; set; }
        public string Filler1 { get; set; }
        public string State_Tax_on_Product { get; set; }
        public string State_Tax_on_POS_Sales { get; set; }
        public string Primary_Last_Name { get; set; }
        public string Account_Handling_Fee { get; set; }
        public string Disbursement_Fee { get; set; }
        public string Transmitter_GUID { get; set; }
        public string Service_Bureau_Fees_On_Hold { get; set; }
        public string Site_Fees_On_Hold { get; set; }
        public string ERO_POS_Fee_1 { get; set; }
        public string ERO_POS_Fee_2 { get; set; }
        public string ERO_POS_Fee_3 { get; set; }
        public string TPG_Internal_Use_E1 { get; set; }
        public string TPG_Internal_Use_D { get; set; }
        public string TPG_Internal_Use_E2 { get; set; }
        public string TPG_Internal_Use_E3 { get; set; }
        public string TPG_Internal_Use_E4 { get; set; }
        public string TPG_Internal_Use_E5 { get; set; }
        public string Settlement_Date { get; set; }
        public string Filler2 { get; set; }
    }
    class clsVRecord
    {
        public string Record_Type { get; set; }
        public string Record_Sub_Type { get; set; }
        public string Primary_SSN { get; set; }
        public string Secondary_SSN { get; set; }
        public string Master_EFIN { get; set; }
        public string EFIN { get; set; }
        public string Office_IDENT { get; set; }
        public string ADJ_Number { get; set; }
        public string ADJ_RECD_Amount { get; set; }
        public string ADJ_RECD_Date { get; set; }
        public string ADJ_REV_Date { get; set; }
        public string EXP_IRS_ACH_Date { get; set; }
        public string Total_IRS_ADJ_RECD_Amount { get; set; }
        public string Total_Manual_ADJ_RECD_Amount { get; set; }
        public string Total_State_ADJ_RECD_Amount { get; set; }
        public string Product_Indicator { get; set; }
        public string State_of_Adjustment { get; set; }
        public string Primary_Last_Name { get; set; }
        public string Transmitter_GUID { get; set; }
        public string Filler { get; set; }
    }
    class clsCRecord
    {
        public string Record_Type { get; set; }
        public string Record_Sub_Type { get; set; }
        public string Primary_SSN { get; set; }
        public string Secondary_SSN { get; set; }
        public string Master_EFIN { get; set; }
        public string EFIN { get; set; }
        public string Office_IDENT { get; set; }
        public string DISB_Number { get; set; }
        public string Check_DISB_Amount { get; set; }
        public string Check_SEQ_Number { get; set; }
        public string Check_DISB_Date { get; set; }
        public string Check_CLR_Date { get; set; }
        public string Primary_Last_Name { get; set; }
        public string Check_Cash_Date { get; set; }
        public string Check_Verified_Date { get; set; }
        public string Product_Indicator { get; set; }
        public string Transmitter_GUID { get; set; }
        public string Filler { get; set; }
    }
    class GRecord
    {
        public string Record_Type { get; set; }
        public string Record_Sub_Type { get; set; }
        public string Primary_SSN { get; set; }
        public string Secondary_SSN { get; set; }
        public string Master_EFIN { get; set; }
        public string EFIN { get; set; }
        public string Office_IDENT { get; set; }
        public string DISB_Number { get; set; }
        public string ADJ_Number { get; set; }
        public string Filler { get; set; }
    }
    class ZRecord
    {
        public string Record_Type { get; set; }
        public string Record_Sub_Type { get; set; }
        public string Filler1 { get; set; }
        public string Master_EFIN { get; set; }
        public string EFIN { get; set; }
        public string Office_IDENT { get; set; }
        public string Filler2 { get; set; }
        public string Company_Name { get; set; }
        public string Contact_First_Name { get; set; }
        public string Contact_Last_Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip_Code { get; set; }
        public string Company_Telephone_Number { get; set; }
        public string Company_Fax_Number { get; set; }
        public string Company_RTN { get; set; }
        public string Company_DAN { get; set; }
        public string Company_ACCT_Type { get; set; }
        public string Filler3 { get; set; }
        public string EIN_or_SSN { get; set; }
        public string Contact_E_Mail_Address { get; set; }
        public string Transmitter_Use { get; set; }
        public string Filler4 { get; set; }
        public string Fee_Intercept_Amount { get; set; }
        public string Fee_Intercept_Indicator { get; set; }
        public string Fee_Intercept_Percentage { get; set; }
        public string TPG_Internal_Use_A { get; set; }
        public string TPG_Internal_Use_B { get; set; }
        public string TPG_Internal_Use_E1 { get; set; }
        public string TPG_Internal_Use_E2 { get; set; }
        public string Filler5 { get; set; }
    }
    class clsDRecord
    {
        public string Record_Type { get; set; }
        public string Record_Sub_Type { get; set; }
        public string Primary_SSN_or_Batch_IDENT { get; set; }
        public string Secondary_SSN { get; set; }
        public string Master_EFIN { get; set; }
        public string EFIN { get; set; }
        public string Office_IDENT { get; set; }
        public string RESERVED { get; set; }
        public string Original_Product_Code { get; set; }
        public string Taxpayer_Under_Review_Indicator { get; set; }
        public string Z_Record_Not_Set_Up_Indicator { get; set; }
        public string Primary_Last_Name { get; set; }
        public string Transmitter_Use { get; set; }
        public string Enrollment_Sub_status { get; set; }
        public string Enrollment_Status { get; set; }
        public string Compliance_Flag { get; set; }
        public string Filler1 { get; set; }
        public string Transmitter_GUID { get; set; }
        public string ERO_FCA_Status { get; set; }
        public string DISB_Number { get; set; }
        public string DISB_Amount { get; set; }
        public string Fast_Cash_Advance_Enrollment_Sub_status { get; set; }
        public string PreSeason_Advance_Owed { get; set; }
        public string Filing_Year { get; set; }
        public string Advance_Plus_Opt_In { get; set; }
        public string Filler2 { get; set; }
        public string Transmitter_ID { get; set; }
        public string SPC_SEQ_Number { get; set; }
        public string Fee_Pay_Flag { get; set; }
        public string Instant_Card_Opt_In { get; set; }
        public string Fee_Advance_Opt_In { get; set; }
        public string Fee_Intercept_Collected_Amount { get; set; }
        public string Fee_Intercept_To_Collect_Amount { get; set; }
        public string TPG_Internal_Use_G { get; set; }
        public string TPG_Internal_Use_I_1 { get; set; }
        public string TPG_Internal_Use_I_5 { get; set; }
        public string TPG_Internal_Use_I_6 { get; set; }
        public string Ack_Origination { get; set; }
        public string TPG_Internal_Use_I_8 { get; set; }
        public string TPG_Internal_Use_I_9 { get; set; }
        public string TPG_Internal_Use_E1 { get; set; }
        public string TPG_Internal_Use_E2 { get; set; }
        public string TPG_Internal_Use_E3 { get; set; }
        public string Remote_Check_Printing { get; set; }
        public string Taxpayer_Pre_Ack_Advance_Status { get; set; }
        public string Taxpayer_Fast_Cash_Advance_Status { get; set; }
        public string Taxpayer_Advance_Plus_Status { get; set; }
        public string Other_Debt_Owed { get; set; }
        public string InSeason_Advance_Owed { get; set; }
        public string ERO_TP_Advance_Program { get; set; }
        public string Pre_Ack_Advance_Eligible { get; set; }
        public string SPA_Status_Indicator_field { get; set; }
        public string Filler3 { get; set; }
    }
    class clsBRecord
    {
        public string ERO_FCA_Status { get; set; }
        public string Enrollment_Sub_status { get; set; }
        public string Enrollment_Status { get; set; }
        public string Compliance_Flag { get; set; }
        public string Allow_Cards { get; set; }
        public string Z_Record_Unlocked { get; set; }
        public string Dupe_P_Record_2014_Sub_Code { get; set; }
        public string Filler2 { get; set; }
        public string Transmitter_ID { get; set; }
        public string Fee_Pay_Flag { get; set; }
        public string Instant_Card_Opt_In { get; set; }
        public string Fee_Advance_Opt_In { get; set; }
        public string SPC_SEQ_Number { get; set; }
        public string Fee_Intercept_Collected_Amount { get; set; }
        public string Fee_Intercept_To_Collect_Amount { get; set; }
        public string TPG_Internal_Use_G { get; set; }
        public string TPG_Internal_Use_I_1 { get; set; }
        public string TPG_Internal_Use_I_5 { get; set; }
        public string TPG_Internal_Use_I_6 { get; set; }
        public string Ack_Origination { get; set; }
        public string TPG_Internal_Use_I_8 { get; set; }
        public string TPG_Internal_Use_I_9 { get; set; }
        public string Fast_Cash_Advance_Enrollment_Sub_status { get; set; }
        public string PreSeason_Advance_Owed { get; set; }
        public string Advance_Plus_Opt_In { get; set; }
        public string Taxpayer_Pre_Ack_Advance_Status { get; set; }
        public string Taxpayer_Fast_Cash_Advance_Status { get; set; }
        public string Taxpayer_Advance_Plus_Status { get; set; }
        public string Other_Debt_Owed { get; set; }
        public string InSeason_Advance_Owed { get; set; }
        public string Software_Purchase_Assistance_Owed { get; set; }
        public string ERO_TP_Advance_Program { get; set; }
        public string Pre_Ack_Advance_Eligible { get; set; }
        public string SPA_Status_Indicatorfield { get; set; }
        public string Filler3 { get; set; }
    }
    class clsXRecord
    {
        public string Record_Type { get; set; }
        public string Record_Sub_Type { get; set; }
        public string Filler1 { get; set; }
        public string Transmitter_Name { get; set; }
        public string Batch_DateTime { get; set; }
        public string Batch_IDENT { get; set; }
        public string Total_Record_Count { get; set; }
        public string Total_Record_Amount { get; set; }
        public string X_Record_Count { get; set; }
        public string R_Record_Count { get; set; }
        public string R_Record_Amount { get; set; }
        public string A_Record_Count { get; set; }
        public string A_Record_Amount { get; set; }
        public string U_Record_Count { get; set; }
        public string U_Record_Amount { get; set; }
        public string P_Record_Count { get; set; }
        public string P_Record_Amount { get; set; }
        public string S_Record_Count { get; set; }
        public string S_Record_Amount { get; set; }
        public string C_Record_Count { get; set; }
        public string C_Record_Amount { get; set; }
        public string F_Record_Count { get; set; }
        public string F_Record_Amount { get; set; }
        public string V_Record_Count { get; set; }
        public string V_Record_Amount { get; set; }
        public string G_Record_Count { get; set; }
        public string Z_Record_Count { get; set; }
        public string B_Record_Count { get; set; }
        public string D_Record_Count { get; set; }
        public string O_Record_Count { get; set; }
        public string TPG_Internal_Use_B { get; set; }
        public string Filler2 { get; set; }
    }
}

