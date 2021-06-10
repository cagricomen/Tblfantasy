import HomePage from 'components/pages/home-page'
import Fixture from 'components/pages/content/fixture'
import ScoreHistory from 'components/pages/content/teamdesign'
import TeamStats from 'components/pages/content/teamstats'
import FakeUser from 'components/pages/content/fakeuser'
import Forbidden from 'components/root/forbidden'

export const routes = [
  {
    name: 'home-page',
    path: '/pages/home-page',
    component: HomePage,
    display: 'Home Page',
    icon: 'home'
  },
  {
    name: 'fixture',
    path: '/pages/content/fixture',
    component: Fixture,
    display: 'Fixture',
    icon: 'basketball-ball',
  },
  {
    name: 'teamdesign',
    path: '/pages/content/teamdesign/',
    component: ScoreHistory,
    display: 'Team Design',
    icon: 'poll',
    hidden: true
  },
  {
    name: 'teamstats',
    path: '/pages/content/teamstats',
    component: TeamStats,
    display: 'Team Stats',
    icon: 'list-alt'
  },
  {
    name: 'fakeuser',
    path: '/pages/content/fakeuser',
    component: FakeUser,
    display: 'All fixture',
    icon: 'list-alt'
  },
  {
    divider: true,
    path: ''
  },
  {
    name: 'account-view',
    path: '/Identity/Account/Manage',
    display: 'Account',
    icon: 'user-circle'
  },
  {
    name: 'forbidden',
    path: '/forbidden',
    hidden: "true",
    component: Forbidden
  },
]
