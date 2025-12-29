# HHTPRO - Database Security Management System
### Introduction
This project focuses on building a secure Retail Management System using Oracle Database. The system is designed with multi-layered security protocols to protect sensitive business data, including customer information, financial transactions, and employee records.

### Core Database Security Features
#### A. User Authentication & Profile Security
The system implements strict password policies and session management using Oracle Profiles:

Password Expiration: Passwords must be changed every 20 days.

Brute-force Protection: Accounts are automatically locked for 1 minute after 3 failed login attempts.

Session Management: Sessions are terminated after 60 minutes of inactivity (Idle Time).

Password Reuse: Prevents users from reusing their last 5 passwords.

#### B. Access Control (RBAC)
Access is managed through a Role-Based Access Control system to ensure the principle of least privilege:

ROLE_CHUSHOP: Full administrative access, including CRUD operations on all tables and user management.

ROLE_NHANVIEN: Restricted access to sales and inventory data (SanPham, KhachHang, DonHang).

System Privileges: Fine-grained granting of system permissions like CREATE SESSION, CREATE TABLE, and GRANT ANY ROLE only to authorized administrators.

#### C. Oracle Label Security (OLS)
The system applies Row-Level Security through OLS to control data visibility based on user clearance:

Policy Name: SHOP_SECURITY_POLICY.

Security Levels:

NHANVIEN (NV): Lower clearance for standard staff.

CHUSHOP (CS): Higher clearance for management.

Protected Tables: DONHANG, NHANVIEN, and LICHSUDANGNHAP columns are labeled to ensure users only see data corresponding to their assigned security label.

#### D. System Auditing
Comprehensive auditing is enabled to track all critical activities and maintain an audit trail for forensic analysis:

System Auditing: Monitors session creation, user modifications, and privilege granting.

Object Auditing: Tracks all DML actions (SELECT, INSERT, UPDATE, DELETE) on core tables such as DonHang, TaiKhoan, and NhanVien.

User-Specific Auditing: Targeted monitoring for high-privilege accounts.

### 3. Database Schema Overview
The system consists of the following modules:

Inventory: SanPham, PhieuNhapHang, ChiTietPhieuNhapHang.

Sales: KhachHang, DonHang, ChiTietDonHang, KhuyenMai.

Human Resources: NhanVien, TaiKhoan, LichSuDangNhap.

Warranty: PhieuBaoHanh, PhieuTraHang.

### Installation & Deployment
Prerequisites: Oracle Database with LBACSYS (Oracle Label Security) enabled.

Setup:

Run the initial user and role creation scripts.

Execute the Table Schema definitions.

Apply the OLS Policies and Labels.

Enable the Auditing commands.

### Security Views
The system provides pre-configured views for secure reporting:

vw_HoaDon: Consolidates order details, staff, and customer information with total calculations.

vw_PhieuBaoHanh: Links warranty certificates with order history.

vw_PhieuHen: Manages product return schedules.
