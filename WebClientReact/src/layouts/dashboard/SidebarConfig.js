import { Icon } from '@iconify/react';
import calendarOutline from '@iconify/icons-eva/calendar-outline';
import pieChartOutline from '@iconify/icons-eva/pie-chart-outline';
import peopleOutline from '@iconify/icons-eva/people-outline';
import folderOutline from '@iconify/icons-eva/folder-outline';
import barChartFill from '@iconify/icons-eva/bar-chart-fill';
import checkmarkSquareOutline from '@iconify/icons-eva/checkmark-square-outline';
import gridOutline from '@iconify/icons-eva/grid-outline';
import messageSquareOutline from '@iconify/icons-eva/message-square-outline';
// ----------------------------------------------------------------------

const getIcon = (name) => <Icon icon={name} width={22} height={22} />;

const sidebarConfig = [
  {
    title: 'dashboard',
    path: '/dashboard/app',
    icon: getIcon(gridOutline)
  },
  {
    title: 'definitions',
    path: '/dashboard/definitions',
    icon: getIcon(pieChartOutline)
  },
  {
    title: 'clients',
    path: '/dashboard/clients',
    icon: getIcon(peopleOutline)
  },
  {
    title: 'cases',
    path: '/dashboard/cases',
    icon: getIcon(folderOutline)
  },
  {
    title: 'transaction activities',
    path: '/dashboard/accountActivities',
    icon: getIcon(barChartFill)
  },
  {
    title: 'tasks',
    path: '/dashboard/tasks',
    icon: getIcon(checkmarkSquareOutline)
  },
  {
    title: 'Events',
    path: '/dashboard/calendar',
    icon: getIcon(calendarOutline)
  },
  ,
  {
    title: 'Messages',
    path: '/dashboard/Messages',
    icon: getIcon(messageSquareOutline)
  }
];

export default sidebarConfig;
