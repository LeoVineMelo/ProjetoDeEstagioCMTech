import * as React from 'react';
import { useEffect } from "react";
import Snackbar from '@mui/material/Snackbar';
import Alert from '@mui/material/Alert';


export function MySnackbar(props) {
	const { message, isOpen, toClose, variant } = props;
	const vertical = 'top';
	const horizontal= 'right';

	const [open, setOpen] = React.useState(false);

	useEffect(() => {
		setOpen(isOpen);
	}, [isOpen]);
	
	const handleClose = () => {
		setOpen(false);
		toClose();
	};


	return (
		<div>
			<Snackbar
				anchorOrigin={{ vertical, horizontal }}
				open={open}
				autoHideDuration={6000}
				onClose={handleClose}
				key={vertical + horizontal}
				>
				<Alert onClose={handleClose} severity={variant} sx={{ width: '100%' }}>
					{message}
				</Alert>
			</Snackbar>

		</div>
	);
}