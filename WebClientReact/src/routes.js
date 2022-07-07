import { Navigate, useRoutes } from 'react-router-dom';
// layouts
import DashboardLayout from './layouts/dashboard';
import LogoOnlyLayout from './layouts/LogoOnlyLayout';
//
import Login from './pages/Login';
import Register from './pages/Register';
import DashboardApp from './pages/DashboardApp';
import User from './pages/User';
import NotFound from './pages/Page404';
import Clients from './pages/Clients';
import Cases from './pages/Cases';
import AccountActivities from './pages/AccountActivities';
import Tasks from './pages/Tasks';
import Documents from './pages/Documents';
import CaseStatus from './pages/CaseStatus';
import Calendar from './pages/Calendar';
import ForgetPassword from './pages/ForgetPassword';
import ApproveUser from './pages/ApproveUser';
import LicencesList from './pages/LicencesList';
import ChangePassword from './pages/ChangePassword';
import AddNewRecords from './pages/AddNewRecords';
import CaseType from "./pages/CaseType";
import AccountActivity from "./pages/AccountActivity";
import ProcessType from "./pages/ProcessType";
import TaskType from "./pages/TaskType";
import CourtOffice from "./pages/CourtOffice";
import LicenceSettings from "./pages/LicenceSettings";
import ConnectedLicences from "./pages/ConnectedLicences";
import Balance from "./pages/Balance";
import AddUsers from "./pages/AddUsers";
import Messages from "./pages/Messages";
import UserList from "./pages/UserList";
import Permission from "./pages/Permission";
import Attachment from "./pages/Attachment";
import PostDrafts from "./pages/PostDrafts";
import SentMessages from "./pages/SentMessages";
import {ProfileForm} from "./components/authentication/Profile";
import Support from "./pages/Support";
import AdminDashboard from "./adminPages/AdminDashboard";
import AdminDashboardLayout from "./layouts/adminDashboard";
import AdminLicences from "./adminPages/AdminLicences";
import AdminUsers from "./adminPages/AdminUsers";
import AdminBalanceTracking from "./adminPages/AdminBalanceTracking";
import CaseUpdateHistory from "./pages/CaseUpdateHistory";
import AdminLicencesDetails from "./adminPages/AdminLicencesDetails";
import AdminSmsHistory from "./adminPages/AdminSmsHistory";
import AdminSupport from "./adminPages/AdminSupport";
import AdminUsersDetails from "./adminPages/AdminUsersDetails";

// ----------------------------------------------------------------------

export default function Router() {
  return useRoutes([
    {
      path: '/dashboard',
      element: <DashboardLayout />,
      children: [
        { element: <Navigate to="/dashboard/app" replace /> },
        { path: 'app', element: <DashboardApp /> },
        { path: 'definitions', element: <User /> },
        { path: 'clients', element: <Clients /> },
        { path: 'cases', element: <Cases /> },
        { path: 'accountActivities', element: <AccountActivities /> },
        { path: 'tasks', element: <Tasks /> },
        { path: 'documents', element: <Documents /> },
        { path: 'calendar', element: <Calendar /> },
        { path: 'definitions/caseStatus', element: <CaseStatus /> },
        { path: 'definitions/caseType', element: <CaseType /> },
        { path: 'definitions/processType', element: <ProcessType /> },
        { path: 'definitions/taskType', element: <TaskType /> },
        { path: 'definitions/courtOffice', element: <CourtOffice /> },
        { path: 'definitions/transactionActivity', element: <AccountActivity /> },
        { path: 'addNewRecords', element: <AddNewRecords /> },
        { path: 'licenceSettings', element: <LicenceSettings /> },
        { path: 'licenceSettings/addUsers', element: <AddUsers /> },
        { path: 'Messages', element: <Messages /> },
        { path: 'cases/attachment/:id', element: <Attachment /> },
        { path: 'Messages/postDrafts', element: <PostDrafts /> },
        { path: 'Messages/sentMessages', element: <SentMessages /> },
        { path: 'licenceSettings/userList', element: <UserList /> },
        { path: 'licenceSettings/userList/permission/:id', element: <Permission /> },
        { path: 'connectedLicences', element: <ConnectedLicences /> },
        { path: 'licenceSettings/balance', element: <Balance /> },
        { path: 'profile', element: <ProfileForm /> },
        { path: 'support', element: <Support /> },
        { path: 'cases/caseUpdateHistory/:id', element: <CaseUpdateHistory /> }
      ]
    },
    {
      path: '/adminDashboard',
      element: <AdminDashboardLayout />,
      children: [
        { element: <Navigate to="/adminDashboard/admin" replace /> },
        { path: 'admin', element: <AdminDashboard /> },
        { path: 'support', element: <AdminSupport /> },
        { path: 'licences', element: <AdminLicences /> },
        { path: 'users', element: <AdminUsers /> },
        { path: 'users/usersDetails/:id', element: <AdminUsersDetails /> },
        { path: 'balanceTracking', element: <AdminBalanceTracking /> },
        { path: 'licences/licencesDetails/:id', element: <AdminLicencesDetails /> },
        { path: 'licences/licencesDetails/smsHistory/:id', element: <AdminSmsHistory /> }
      ]
    },
    {
      path: '/',
      element: <LogoOnlyLayout />,
      children: [
        { element: <Navigate to="/login" replace /> },
        { path: 'login', element: <Login /> },
        { path: 'register', element: <Register /> },
        { path: 'approveUser', element: <ApproveUser /> },
        { path: 'changePassword', element: <ChangePassword /> },
        { path: '404', element: <NotFound /> },
        { path: '/', element: <Navigate to="/dashboard" /> },
        { path: '*', element: <Navigate to="/404" /> },
        { path: 'forgotPassword', element: <ForgetPassword /> },
        { path: 'licencesList/:id', element: <LicencesList /> },
      ]
    },
    { path: '*', element: <Navigate to="/404" replace /> }
  ]);
}
