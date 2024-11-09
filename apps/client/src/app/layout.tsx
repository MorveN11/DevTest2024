import type { Metadata } from 'next';
import '@/styles/globals.css';
import { AppRouterCacheProvider } from '@mui/material-nextjs/v15-appRouter';
import { Toaster } from 'sonner';
import { NavBar } from '@/components/nav-bar';

export const metadata: Metadata = {
  title: 'Poll App',
  description: 'An App for vote in polls'
};

export default function RootLayout({
  children
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body className="flex flex-col gap-10 min-h-screen bg-slate-100">
        <NavBar />
        <AppRouterCacheProvider>{children} </AppRouterCacheProvider>
        <Toaster />
      </body>
    </html>
  );
}
